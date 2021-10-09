using BELibrary.Core.Entity;
using BELibrary.Entity;
using BELibrary.Utils;
using ELearning.Areas.Admin.Authorization;
using ELearning.Areas.Admin.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace ELearning.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Administrator/Login/

        [HttpGet]
        public ActionResult Index(string ReturnUrl = "")
        {
            if (CookiesManage.Logined())
            {
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        public JsonResult ChangePass(string oldPass, string newPass, string reNewPass)
        {
            if (Session[SessionKey.Admin] != null)
            {
                User user = (User)Session[SessionKey.Admin];
                if (!user.Password.Equals(oldPass))
                {
                    return Json(new { status = false, mess = "Mật khẩu cũ không khớp!" });
                }
                if (!newPass.Equals(reNewPass))
                {
                    return Json(new { status = false, mess = "Mật khẩu không khớp!" });
                }
                var unitOfWork = new UnitOfWork(new ELearningDBContext());
                var us = unitOfWork.Account.ValidBEAccount(user.Username, user.Password);
                us.Password = newPass;
                unitOfWork.Complete();
                return Json(new { status = true, mess = "Đổi mật khẩu thành công!", url = "/Login/Logout" });
            }
            return Json(new { status = "login", mess = "Đăng nhập lại!", url = "/Login/Index" });
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult CheckLogin(LoginModel model)
        {
            var unitofwork = new UnitOfWork(new ELearningDBContext());
            var account = unitofwork.Account.ValidBEAccount(model.Username, model.Password);

            if (account != null)
            {
                //đăng nhập thành công
                string cookieclient = account.Username;
                string decodecookieclient = CryptorEngine.Encrypt(cookieclient, true);
                HttpCookie usercookie = new HttpCookie("name_client")
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

        //[HttpGet]
        //[ValidateInput(true)]
        //public ActionResult GetPassWord()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateInput(true)]
        //public ActionResult GetPassWord(GetPassword model)
        //{
        //    using (var db = new MrLongToeicEntities())
        //    {
        //        User detailUser =
        //            db.Users.FirstOrDefault(a => a.Email == model.Email && a.UserName == model.UserName);
        //        if (Convert.ToDateTime(CurrentSession.LockUser) > DateTime.Now)
        //        {
        //            DateTime dateBlog = Convert.ToDateTime(CurrentSession.LockUser);
        //            int minuteLock = dateBlog.Minute + (dateBlog.Hour*60) - DateTime.Now.Minute - (DateTime.Now.Hour*60);
        //            ModelState.AddModelError("Email",
        //                "Bạn đã nhập quá nhiều lần quy định, xin vui lòng quay lại sau " + minuteLock + " Phút.");
        //            return View();
        //        }
        //        if (detailUser == null)
        //        {
        //            if (TempData["Count"] == null)
        //            {
        //                TempData["Count"] = 1;
        //                TempData.Keep("Count");
        //            }
        //            else
        //            {
        //                TempData["Count"] = int.Parse(TempData["Count"].ToString()) + 1;
        //                TempData.Keep("Count");
        //            }
        //            if (int.Parse(TempData["Count"].ToString()) == 5)
        //            {
        //                DateTime dateBlog = DateTime.Now.AddMinutes(1);
        //                CurrentSession.LockUser = dateBlog;
        //                int minuteLock = dateBlog.Minute + (dateBlog.Hour*60) - DateTime.Now.Minute -
        //                                 (DateTime.Now.Hour*60);
        //                TempData.Remove("Count");
        //                ModelState.AddModelError("Email",
        //                    "Bạn đã nhập quá nhiều lần quy định, xin vui lòng quay lại sau " + minuteLock + " phút.");
        //                return View();
        //            }
        //            ModelState.AddModelError("Email",
        //                "Email hoặc tên người dùng là không chính xác, bạn còn " +
        //                (5 - int.Parse(TempData["Count"].ToString())) + " lần nhập");

        //            return View();
        //        }
        //        string content =
        //            System.IO.File.ReadAllText(Server.MapPath("/Areas/Admin/lib/Forgot_Password.html"));

        //        content = content.Replace("{{Password}}", CryptorEngine.Decrypt(detailUser.PasswordOld, true));

        //        MailHelper.SendMail(detailUser.Email, "Lấy lại mật khẩu", content);

        //        ViewBag.Messeages = "Vui lòng đăng nhập vào địa chỉ email: " + model.Email + " để lấy lại mật khẩu.";
        //        return View();
        //    }
        //}

        [HttpGet]
        public ActionResult Logout()
        {
            HttpCookie namecookie = Request.Cookies["name_client"];
            if (namecookie != null)
            {
                HttpCookie myCookie = new HttpCookie("name_client")
                {
                    Expires = DateTime.Now.AddDays(-1d)
                };
                Response.Cookies.Add(myCookie);
            }
            return Redirect("/admin/login");
        }
    }
}