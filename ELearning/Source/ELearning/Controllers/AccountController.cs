using BELibrary.Core.Entity;
using BELibrary.Entity;
using BELibrary.Utils;
using ELearning.Areas.Admin.Models;
using ELearning.Handler;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ELearning.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(int? page)
        {
            if (!CookiesManage.Logined())
            {
                return RedirectToAction("Login", "Account");
            }

            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var user = CookiesManage.GetUser();

                //Lấy danh sách khóa học được user hiện tại đăng ký
                var listCourseReg = unitofwork.StudentSubjects.GetAll().Where(x => x.Username == user.Username);

                Expression<Func<Subject, object>>[] includes = new Expression<Func<Subject, object>>[1];
                includes[0] = x => x.Course;

                var subjects = unitofwork.Subjects.Include(includes);

                var listData = from cReg in listCourseReg
                               join s in subjects on cReg.SubjectId equals s.Id
                               select s;

                int pageNumber = (page ?? 1);
                int pageSize = 4;
                return View(listData.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Edit()
        {
            if (!CookiesManage.Logined())
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var user = CookiesManage.GetUser();

                using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                {
                    var account = unitofwork.Account.GetAll().Where(x => x.Username.Trim().ToLower() == user.Username.Trim().ToLower());
                    return View(account);
                }
            }
        }

        public ActionResult Login(string ReturnUrl = "")
        {
            if (CookiesManage.Logined())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult CheckLogin(LoginModel model)
        {
            var unitofwork = new UnitOfWork(new ELearningDBContext());
            var account = unitofwork.Account.ValidFEAccount(model.Username, model.Password);

            if (account != null)
            {
                //đăng nhập thành công
                string cookieclient = account.Username;
                string decodecookieclient = CryptorEngine.Encrypt(cookieclient, true);
                HttpCookie usercookie = new HttpCookie("name_student")
                {
                    Value = decodecookieclient,
                    Expires = DateTime.Now.AddDays(30)
                };
                HttpContext.Response.Cookies.Add(usercookie);
                return Json(new { status = true, mess = "Đăng nhập thành công" });
            }
            else
            {
                return Json(new { status = false, mess = "Tên và mật khẩu không chính xác" });
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult Register(User us, string RePassword)
        {
            if (us.Password != RePassword)
            {
                return Json(new { status = false, mess = "Mật khẩu không khớp" });
            }
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var account = unitofwork.Account.FirstOrDefault(x => x.Username.ToLower() == us.Username.ToLower());
                if (account == null)
                {
                    try
                    {
                        var passwordFactory = us.Password + VariableExtensions.KeyCryptor;
                        var passwordCrypto = CryptorEngine.Encrypt(passwordFactory, true);
                        us.RoleId = RoleKey.Student;
                        us.Status = true;
                        us.Password = passwordCrypto;

                        us.LinkAvata = us.Gender == GenderKey.Male ? "/Content/images/team/2.png" : "/Content/images/team/3.png";
                        unitofwork.Account.Add(us);
                        unitofwork.Complete();

                        //Login luon
                        var cookieClient = us.Username;
                        var decodeCookieClient = CryptorEngine.Encrypt(cookieClient, true);

                        var userCookie = new HttpCookie("name_student")
                        {
                            Value = decodeCookieClient,
                            Expires = DateTime.Now.AddDays(30)
                        };
                        HttpContext.Response.Cookies.Add(userCookie);

                        return Json(new { status = true, mess = "Đăng ký thành công" });
                    }
                    catch (Exception)
                    {
                        return Json(new { status = false, mess = "Thêm không thành công" });
                    }
                }
                else
                {
                    return Json(new { status = false, mess = "Username không khả dụng" });
                }
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult Update(User us, HttpPostedFileBase avatarUpload)
        {
            if (!CookiesManage.Logined())
            {
                return Json(new { status = false, mess = "Chưa đăng nhập" });
            }
            var user = CookiesManage.GetUser();
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var account = unitofwork.Account.FirstOrDefault(x => x.Username.ToLower() == user.Username.ToLower());
                if (account != null)
                {
                    try
                    {
                        if (avatarUpload != null && avatarUpload.FileName != null)
                        {
                            if (avatarUpload.ContentLength >= FileKey.MaxLength)
                            {
                                return Json(new { status = false, mess = L.T("FileMaxLength") });
                            }
                            var splitFilename = avatarUpload.FileName.Split('.');
                            if (splitFilename.Length > 1)
                            {
                                var fileExt = splitFilename[splitFilename.Length - 1];

                                //Check ext

                                if (FileKey.FileExtensionApprove().Any(x => x == fileExt))
                                {
                                    string slugName = StringHelper.ConvertToAlias(account.FullName);
                                    string fileName = slugName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + fileExt;
                                    var path = Path.Combine(Server.MapPath("~/FileUploads/images/avatas/"), fileName);
                                    avatarUpload.SaveAs(path);
                                    us.LinkAvata = "/FileUploads/images/avatas/" + fileName;
                                }
                                else
                                {
                                    return Json(new { status = false, mess = L.T("FileExtensionReject") });
                                }
                            }
                            else
                            {
                                return Json(new { status = false, mess = L.T("FileExtensionReject") });
                            }
                        }

                        us.RoleId = RoleKey.Student;
                        us.Status = true;
                        us.Password = account.Password;
                        us.Username = account.Username;
                        if (string.IsNullOrEmpty(us.LinkAvata))
                        {
                            us.LinkAvata = us.Gender == GenderKey.Male ? "/Content/images/team/2.png" : "/Content/images/team/3.png";
                        }
                        unitofwork.Account.Put(us, us.Username);
                        unitofwork.Complete();

                        //Đăng xuất
                        var nameCookie = Request.Cookies["name_student"];
                        if (nameCookie != null)
                        {
                            var myCookie = new HttpCookie("name_student")
                            {
                                Expires = DateTime.Now.AddDays(-1d)
                            };
                            Response.Cookies.Add(myCookie);
                        }

                        //Login luon
                        var cookieClient = us.Username;
                        var decodeCookieClient = CryptorEngine.Encrypt(cookieClient, true);

                        var userCookie = new HttpCookie("name_student")
                        {
                            Value = decodeCookieClient,
                            Expires = DateTime.Now.AddDays(30)
                        };
                        HttpContext.Response.Cookies.Add(userCookie);

                        return Json(new { status = true, mess = "Cập nhật thành công" });
                    }
                    catch (Exception ex)
                    {
                        return Json(new { status = false, mess = "Cập nhật không thành công", ex });
                    }
                }
                else
                {
                    return Json(new { status = false, mess = "Tài khoản không khả dụng" });
                }
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult UpdatePass(string OldPassword, string NewPassword, string RePassword)
        {
            if (OldPassword == "" || NewPassword == "" || RePassword == "")
            {
                return Json(new { status = false, mess = "Không được để trống" });
            }
            if (!CookiesManage.Logined())
            {
                return Json(new { status = false, mess = "Chưa đăng nhập" });
            }
            if (NewPassword != RePassword)
            {
                return Json(new { status = false, mess = "Mật khẩu không khớp" });
            }
            var user = CookiesManage.GetUser();
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var account = unitofwork.Account.FirstOrDefault(x => x.Username.ToLower() == user.Username.ToLower());
                if (account != null)
                {
                    try
                    {
                        string passwordFactory = OldPassword + VariableExtensions.KeyCryptor;
                        string passwordCryptor = CryptorEngine.Encrypt(passwordFactory, true);

                        if (passwordCryptor == account.Password)
                        {
                            passwordFactory = "";
                            passwordCryptor = "";

                            passwordFactory = NewPassword + VariableExtensions.KeyCryptor;
                            passwordCryptor = CryptorEngine.Encrypt(passwordFactory, true);

                            account.Password = passwordCryptor;
                            unitofwork.Account.Put(account, account.Username);
                            unitofwork.Complete();

                            //Đăng xuất
                            var nameCookie = Request.Cookies["name_student"];
                            if (nameCookie != null)
                            {
                                var myCookie = new HttpCookie("name_student")
                                {
                                    Expires = DateTime.Now.AddDays(-1d)
                                };
                                Response.Cookies.Add(myCookie);
                            }

                            //Login luon
                            var cookieClient = account.Username;
                            var decodeCookieClient = CryptorEngine.Encrypt(cookieClient, true);

                            var userCookie = new HttpCookie("name_student")
                            {
                                Value = decodeCookieClient,
                                Expires = DateTime.Now.AddDays(30)
                            };
                            HttpContext.Response.Cookies.Add(userCookie);

                            return Json(new { status = true, mess = "Cập nhật thành công" });
                        }
                        else
                        {
                            return Json(new { status = false, mess = "mật khẩu cũ không đúng" });
                        }
                    }
                    catch (Exception ex)
                    {
                        return Json(new { status = false, mess = "Cập nhật không thành công", ex });
                    }
                }
                else
                {
                    return Json(new { status = false, mess = "Tài khoản không khả dụng" });
                }
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            var nameCookie = Request.Cookies["name_student"];
            if (nameCookie == null) return RedirectToAction("Index", "Home");
            var myCookie = new HttpCookie("name_student")
            {
                Expires = DateTime.Now.AddDays(-1d)
            };
            Response.Cookies.Add(myCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}