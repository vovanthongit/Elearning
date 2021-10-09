using BELibrary.Core.Entity;
using BELibrary.Entity;
using BELibrary.Utils;
using ELearning.Handler;
using ELearning.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ELearning.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Course
        public ActionResult Index(int? page)
        {
            using (var workScope = new UnitOfWork(new ELearningDBContext()))
            {
                var related = workScope.Subjects.GetAll().OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
                ViewBag.Related = related;

                var includes = new Expression<Func<Subject, object>>[1];
                includes[0] = x => x.Course;
                var items = workScope.Subjects.Include(includes).ToList();

                var pageNumber = (page ?? 1);
                const int pageSize = 4;
                return View(items.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Search(string keyword, int? page)
        {
            if (keyword == "")
            {
                keyword = null;
            }

            ViewBag.Keyword = keyword;

            using (var workScope = new UnitOfWork(new ELearningDBContext()))
            {
                var includes = new Expression<Func<Subject, object>>[1];
                includes[0] = x => x.Course;
                var items = workScope.Subjects.Include(includes).ToList();

                var q = from mt in items
                        where (!string.IsNullOrEmpty(keyword) && mt.Name.ToLower().Contains(keyword.ToLower()))
                          || (!string.IsNullOrEmpty(keyword) && mt.Description.ToLower().Contains(keyword.ToLower()))
                          || (!string.IsNullOrEmpty(keyword) && mt.Content.ToLower().Contains(keyword.ToLower()))
                        select mt;

                var related = workScope.Subjects.GetAll().OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
                ViewBag.Related = related;

                var pageNumber = (page ?? 1);
                const int pageSize = 4;
                var result = q.ToPagedList(pageNumber, pageSize);

                return View(result);
            }
        }

        public ActionResult Detail(int? id)
        {
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var item = unitofwork.Subjects.FirstOrDefault(x => x.Id == id);
                List<Lecture> lst = new List<Lecture>();
                if (CookiesManage.Logined())
                {
                    var user = CookiesManage.GetUser();
                    var studentSubject = unitofwork.StudentSubjects
                           .FirstOrDefault(x => x.Username.ToLower() == user.Username.ToLower()
                           && x.SubjectId == item.Id);

                    if (studentSubject != null)
                    {
                        lst = unitofwork.Lectures.Query(x => x.SubjectId == item.Id).ToList();
                        ViewBag.IsReg = true;
                        ViewBag.Status = studentSubject.Status;
                        ViewBag.IsReg = true;
                    }
                    else
                    {
                        ViewBag.IsReg = false;
                    }
                }

                ViewBag.Item = item;

                string CurrentURL = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
                ViewBag.CurrentURL = CurrentURL;

                return View(lst);
            }
        }

        public ActionResult Lecture(int? id, int? cpage)
        {
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var lecture = unitofwork.Lectures.FirstOrDefault(x => x.Id == id);
                if (!CookiesManage.Logined()) return View(lecture);
                {
                    var user = CookiesManage.GetUser();
                    var studentSubject = unitofwork.StudentSubjects
                        .FirstOrDefault(x => x.Username.ToLower() == user.Username.ToLower()
                                             && x.SubjectId == lecture.SubjectId);

                    if (studentSubject != null)
                    {
                        var lectures = unitofwork.Lectures.Query(x => x.SubjectId == lecture.SubjectId).ToList();
                        ViewBag.Lectures = lectures;
                        ViewBag.IsReg = true;
                        ViewBag.Status = studentSubject.Status;

                        ///Show comment
                        ViewBag.Comments = GetComment(cpage);
                    }
                    else
                    {
                        ViewBag.IsReg = false;
                    }
                }
                return View(lecture);
            }
        }

        public ActionResult SubmitTest(int lectureId)
        {
            if (CookiesManage.Logined())
            {
                using (var workScope = new UnitOfWork(new ELearningDBContext()))
                {
                    var lecture = workScope.Lectures.FirstOrDefault(x => x.Id == lectureId);
                    if (lecture == null || !lecture.IsTest) return RedirectToAction("Index", "Subject");
                    ViewBag.Lecture = lecture;
                    return View();
                }
            }
            else
            {
                return Redirect("/account/login?ReturnUrl=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
            }
        }

        public ActionResult SendTest(int lectureId, HttpPostedFileBase testFile)
        {
            if (!CookiesManage.Logined())
                return Redirect("/account/login?ReturnUrl=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
            var user = CookiesManage.GetUser();
            using (var workScope = new UnitOfWork(new ELearningDBContext()))
            {
                var lecture = workScope.Lectures.FirstOrDefault(x => x.Id == lectureId);
                if (lecture == null || !lecture.IsTest) return RedirectToAction("Index", "Subject");

                var studentTest = new StudentTest
                {
                    Username = user.Username
                };
                try
                {
                    if (testFile?.FileName != null)
                    {
                        if (testFile.ContentLength >= FileKey.MaxTestLength)
                        {
                            return Json(new { status = false, mess = L.T("FileMaxLength") });
                        }
                        var splitFilename = testFile.FileName.Split('.');
                        if (splitFilename.Length > 1)
                        {
                            var fileExt = splitFilename[splitFilename.Length - 1];

                            //Check ext

                            if (FileKey.FileTestExtensionApprove().Any(x => x == fileExt))
                            {
                                var slugName = StringHelper.ConvertToAlias(user.FullName);
                                var fileName = slugName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + fileExt;
                                var path = Path.Combine(Server.MapPath("~/FileUploads/files/test/"), fileName);
                                testFile.SaveAs(path);
                                studentTest.FileAnswer = "/FileUploads/files/test/" + fileName;
                            }
                            else
                            {
                                return RedirectToAction("Error", "Home");
                            }
                        }
                        else
                        {
                            return RedirectToAction("Error", "Home");
                        }
                    }

                    studentTest.LectureId = lecture.Id;
                    studentTest.Status = false;
                    studentTest.Email = user.Email;

                    workScope.StudentTests.Add(studentTest);
                    workScope.Complete();
                    return View();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        private IPagedList<CommentDto> GetComment(int? page)
        {
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                List<CommentDto> commentDtos = new List<CommentDto>();

                var commentsParent = unitofwork.Comments.Query(x => x.Status && x.ReplyId == null).OrderByDescending(x => x.Id);

                foreach (var par in commentsParent)
                {
                    var commentsChil = unitofwork.Comments.Query(x => x.Status && x.ReplyId == par.Id).OrderBy(x => x.Id);

                    List<CommentDto> comments = new List<CommentDto>();

                    foreach (var chil in commentsChil)
                    {
                        comments.Add(new CommentDto
                        {
                            Id = chil.Id,
                            Content = chil.Content,
                            LectureId = chil.LectureId,
                            ReplyId = chil.ReplyId,
                            FullName = chil.User.FullName,
                            Status = chil.Status,
                            Time = chil.Time,
                            Username = chil.Username,
                            AvataUrl = chil.User.LinkAvata,
                            Chills = new List<CommentDto>()
                        });
                    }

                    commentDtos.Add(new CommentDto
                    {
                        Id = par.Id,
                        Content = par.Content,
                        LectureId = par.LectureId,
                        ReplyId = par.ReplyId,
                        FullName = par.User.FullName,
                        Status = par.Status,
                        Time = par.Time,
                        Username = par.Username,
                        AvataUrl = par.User.LinkAvata,
                        Chills = comments
                    });
                }

                int pageNumber = (page ?? 1);
                int pageSize = 4;
                return commentDtos.ToPagedList(pageNumber, pageSize);
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult RegSubject(int id)
        {
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                if (CookiesManage.Logined())
                {
                    var subject = unitofwork.Subjects.FirstOrDefault(x => x.Id == id);
                    if (subject != null)
                    {
                        var user = CookiesManage.GetUser();
                        var studentSubject = unitofwork.StudentSubjects
                               .FirstOrDefault(x => x.Username.ToLower() == user.Username.ToLower()
                               && x.SubjectId == subject.Id);

                        if (studentSubject != null)
                        {
                            return Json(new { status = false, mess = "Đã đăng ký" });
                        }
                        else
                        {
                            StudentSubject std = new StudentSubject
                            {
                                SubjectId = subject.Id,
                                Username = user.Username,
                                Status = StatusRegSubject.Pending,
                                CreatedDate = DateTime.Now
                            };
                            try
                            {
                                unitofwork.StudentSubjects.Add(std);
                                unitofwork.Complete();
                                return Json(new { status = true, mess = "Đăng ký thành công" });
                            }
                            catch (Exception)
                            {
                                return Json(new { status = false, mess = "Đăng ký không thành công" });
                            }
                        }
                    }
                }
                return Json(new { status = false, mess = "Bạn chưa đăng nhập" });
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult Comment(int commentId, int lectureId, string content, bool? isEdit)
        {
            if (content.Length > 0 && lectureId >= 1)
            {
                using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                {
                    if (CookiesManage.Logined())
                    {
                        var lecture = unitofwork.Lectures.FirstOrDefault(x => x.Id == lectureId);
                        var user = CookiesManage.GetUser();
                        if (lecture != null)
                        {
                            if (isEdit.HasValue && isEdit.GetValueOrDefault())
                            {
                                var comment = unitofwork.Comments.FirstOrDefault(x => x.Id == commentId && x.Username == user.Username);

                                if (comment != null)
                                {
                                    comment.Content = content;
                                    comment.Time = DateTime.Now;
                                    unitofwork.Comments.Put(comment, comment.Id);
                                    unitofwork.Complete();

                                    var obj = new
                                    {
                                        comment.Id,
                                        Time = comment.Time.ToString("dd/MM/yyyy HH:mm"),
                                        user.Username,
                                        Content = content
                                    };

                                    //Sửa thành công
                                    return Json(new { status = true, mess = "", obj });
                                }
                                else
                                {
                                    return Json(new { status = false, mess = "Comment không tồn tại" });
                                }
                            }
                            if (commentId == -1)
                            {
                                var comment = new Comment
                                {
                                    LectureId = lecture.Id,
                                    Status = true,
                                    Time = DateTime.Now,
                                    Username = user.Username,
                                    Content = content
                                };
                                unitofwork.Comments.Add(comment);
                                unitofwork.Complete();

                                //Thêm mới comment
                                var obj = new
                                {
                                    comment.Id,
                                    Time = comment.Time.ToString("dd/MM/yyyy HH:mm"),
                                    user.Username,
                                    Content = content
                                };
                                return Json(new { status = true, mess = "", obj });
                            }
                            else
                            {
                                var comment = unitofwork.Comments.FirstOrDefault(x => x.Id == commentId);

                                if (comment != null)
                                {
                                    var reply = new Comment
                                    {
                                        LectureId = lecture.Id,
                                        Status = true,
                                        Time = DateTime.Now,
                                        Username = user.Username,
                                        ReplyId = comment.Id,
                                        Content = content
                                    };

                                    unitofwork.Comments.Add(reply);
                                    unitofwork.Complete();

                                    var obj = new
                                    {
                                        reply.Id,
                                        Time = reply.Time.ToString("dd/MM/yyyy HH:mm"),
                                        user.Username,
                                        Content = content
                                    };

                                    //Thêm mới reply
                                    return Json(new { status = true, mess = "", obj });
                                }
                                else
                                {
                                    return Json(new { status = false, mess = "Comment không tồn tại" });
                                }
                            }
                        }
                        else
                        {
                            return Json(new { status = false, mess = "Bài học không tồn tại" });
                        }
                    }
                    else
                    {
                        return Json(new { status = false, mess = "Bạn chưa đăng nhập" });
                    }
                }
            }
            else
            {
                return Json(new { status = false, mess = "Lỗi dữ liệu" });
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult DelComment(int commentId)
        {
            if (commentId >= 1)
            {
                using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                {
                    if (CookiesManage.Logined())
                    {
                        var user = CookiesManage.GetUser();
                        var comment = unitofwork.Comments.FirstOrDefault(x => x.Id == commentId && x.Username == user.Username);
                        if (comment != null)
                        {
                            var replies = unitofwork.Comments.Query(x => x.ReplyId == comment.Id);

                            foreach (var item in replies)
                            {
                                unitofwork.Comments.Remove(item);
                                unitofwork.Complete();
                            }

                            unitofwork.Comments.Remove(comment);
                            unitofwork.Complete();

                            //xóa thành công
                            return Json(new { status = true, mess = "Xóa comment thành công" });
                        }
                        else
                        {
                            return Json(new { status = false, mess = "Comment không tồn tại" });
                        }
                    }
                    else
                    {
                        return Json(new { status = false, mess = "Bạn chưa đăng nhập" });
                    }
                }
            }
            else
            {
                return Json(new { status = false, mess = "Lỗi dữ liệu" });
            }
        }
    }
}