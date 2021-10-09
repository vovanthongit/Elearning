using BELibrary.Core.Entity;
using BELibrary.Entity;
using BELibrary.Utils;
using ELearning.Areas.Admin.Authorization;
using ELearning.Areas.Admin.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ELearning.Areas.Admin.Controllers
{
    [Permission(Role = RoleKey.Admin)]
    public class MAssignedController : BaseController
    {
        public ActionResult Index(int role)
        {
            switch (role)
            {
                case RoleKey.Teacher:
                    {
                        ViewBag.Element = "Phân công giáo viên";
                        using (var workScope = new UnitOfWork(new ELearningDBContext()))
                        {
                            //Expression<Func<TeacherSubject, object>>[] includes = new Expression<Func<TeacherSubject, object>>[2];
                            ////

                            //includes[0] = x => x.Subject;
                            //includes[0] = x => x.User;
                            //var listData = unitofwork.TeacherSubject.Include(includes).ToList();
                            var subjects = workScope.Subjects.GetAll();
                            var users = workScope.Account.GetAll();
                            var teacherSubjects = workScope.TeacherSubjects.GetAll();

                            var listData = from ts in teacherSubjects
                                           join s in subjects on ts.SubjectId equals s.Id
                                           join u in users on ts.Username equals u.Username
                                           select new TeacherSubjectDto
                                           {
                                               Id = ts.Id,
                                               Username = ts.Username,
                                               FullName = u.FullName,
                                               SubjectId = ts.SubjectId,
                                               SubjectName = s.Name,
                                               StartTime = ts.StartTime,
                                               FinishTime = ts.FinishTime
                                           };

                            return View("Teacher", listData.ToList());
                        }
                    }
                case RoleKey.Student:
                    {
                        ViewBag.Element = "Học sinh đăng ký";
                        using (var workScope = new UnitOfWork(new ELearningDBContext()))
                        {
                            var subjects = workScope.Subjects.GetAll();
                            var users = workScope.Account.GetAll();
                            var studentSubjects = workScope.StudentSubjects.GetAll();

                            var listData = from ss in studentSubjects
                                           join s in subjects on ss.SubjectId equals s.Id
                                           join u in users on ss.Username equals u.Username
                                           select new StudentSubjectDto
                                           {
                                               Id = ss.Id,
                                               Username = ss.Username,
                                               FullName = u.FullName,
                                               SubjectId = ss.SubjectId,
                                               SubjectName = s.Name,
                                               CreatedDate = ss.CreatedDate,
                                               ApproveName = ss.ApproveName,
                                               Status = ss.Status
                                           };

                            return View("Student", listData.ToList());
                        }
                    }
                default:
                    return Redirect("/admin");
            }
        }

        public ActionResult Create(int role)
        {
            ViewBag.isEdit = false;
            if (role == RoleKey.Teacher)
            {
                ViewBag.key = "Thêm mới";
                ViewBag.Element = "Phân công giáo viên";

                using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                {
                    var subject = unitofwork.Subjects.Query(x => x.Status).ToList();
                    ViewBag.Subjects = new SelectList(subject, "Id", "Name");

                    var users = unitofwork.Account.Query(x => x.Status && x.RoleId == RoleKey.Teacher).ToList();
                    ViewBag.Users = new SelectList(users, "Username", "FullName");

                    return View("TeacherCreate");
                }
            }
            else if (role == RoleKey.Student)
            {
                ViewBag.key = "Thêm mới";
                ViewBag.Element = "Đăng ký khóa học";

                using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                {
                    var subject = unitofwork.Subjects.Query(x => x.Status).ToList();
                    ViewBag.Subjects = new SelectList(subject, "Id", "Name");

                    var courses = unitofwork.Courses.Query(x => x.Status).ToList();
                    ViewBag.Courses = new SelectList(courses, "Id", "Name");

                    var users = unitofwork.Account.Query(x => x.Status && x.RoleId == RoleKey.Teacher).ToList();
                    ViewBag.Users = new SelectList(users, "Username", "FullName");

                    return View("StudentCreate");
                }
            }
            else
            {
                return Redirect("/admin");
            }
        }

        public ActionResult Update(int id, int role)
        {
            ViewBag.isEdit = true;
            ViewBag.key = "Sửa";

            switch (role)
            {
                case RoleKey.Teacher:
                    {
                        ViewBag.Element = "Phân công giáo viên";

                        using (var workScope = new UnitOfWork(new ELearningDBContext()))
                        {
                            var subject = workScope.Subjects.Query(x => x.Status).ToList();
                            ViewBag.Subjects = new SelectList(subject, "Id", "Name");

                            var users = workScope.Account.Query(x => x.Status && x.RoleId == RoleKey.Teacher).ToList();
                            ViewBag.Users = new SelectList(users, "Username", "FullName");

                            var teacherSubject = workScope.TeacherSubjects.FirstOrDefault(x => x.Id == id);
                            return View("TeacherCreate", teacherSubject);
                        }
                    }
                case RoleKey.Student:
                    {
                        ViewBag.Element = "Đăng ký môn học";

                        using (var workScope = new UnitOfWork(new ELearningDBContext()))
                        {
                            var subjects = workScope.Subjects.Query(x => x.Status).ToList();
                            ViewBag.Subjects = new SelectList(subjects, "Id", "Name");

                            var users = workScope.Account.Query(x => x.Status && x.RoleId == RoleKey.Student).ToList();
                            ViewBag.Users = new SelectList(users, "Username", "FullName");

                            var studentCourse = workScope.StudentSubjects.FirstOrDefault(x => x.Id == id);
                            return View("StudentCreate", studentCourse);
                        }
                    }
                default:
                    return Redirect("/admin");
            }
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult ApproveStatus(int id, int status)
        {
            if (!StatusRegSubject.Any(status))
            {
                return Json(new { status = false, mess = "Không tồn tại trạng thái này" });
            }
            try
            {
                using (var workScope = new UnitOfWork(new ELearningDBContext()))
                {
                    var elm = workScope.StudentSubjects.Get(id);
                    if (elm != null) //update
                    {
                        elm.ApproveName = GetCurrentUser().FullName;
                        elm.Status = status;
                        workScope.StudentSubjects.Put(elm, elm.Id);
                        workScope.Complete();
                        return Json(new { status = true, mess = "Cập nhập thành công" });
                    }
                    else
                    {
                        return Json(new { status = false, mess = "Không tồn tại yêu cầu" });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, mess = "Có lỗi xảy ra: " + ex.Message });
            }
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEditTeacherSubject(TeacherSubject input, bool isEdit)
        {
            if (CookiesManage.GetUser().RoleId != RoleKey.Admin)
            {
                return Json(new { status = false, mess = "Bạn không có quyền" });
            }
            try
            {
                if (input.FinishTime.HasValue && input.StartTime > input.FinishTime)
                {
                    return Json(new { status = false, mess = "Thời gian không hợp lệ" });
                }
                if (isEdit) //update
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        var elm = unitofwork.TeacherSubjects.Get(input.Id);
                        if (elm != null) //update
                        {
                            elm = input;
                            unitofwork.TeacherSubjects.Put(elm, elm.Id);
                            unitofwork.Complete();
                            return Json(new { status = true, mess = "Cập nhập thành công" });
                        }
                        else
                        {
                            return Json(new { status = false, mess = "Không tồn tại" });
                        }
                    }
                }
                else
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        unitofwork.TeacherSubjects.Add(input);

                        unitofwork.Complete();
                        return Json(new { status = true, mess = "Thêm thành công " });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, mess = "Có lỗi xảy ra: " + ex.Message });
            }
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEditStudentSubject(StudentSubject input, bool isEdit)
        {
            if (CookiesManage.GetUser().RoleId != RoleKey.Admin)
            {
                return Json(new { status = false, mess = "Bạn không có quyền" });
            }
            try
            {
                if (isEdit) //update
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        var elm = unitofwork.StudentSubjects.Get(input.Id);
                        if (elm != null) //update
                        {
                            elm = input;
                            unitofwork.StudentSubjects.Put(elm, elm.Id);
                            unitofwork.Complete();
                            return Json(new { status = true, mess = "Cập nhập thành công" });
                        }
                        else
                        {
                            return Json(new { status = false, mess = "Không tồn tại" });
                        }
                    }
                }
                else
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        unitofwork.StudentSubjects.Add(input);

                        unitofwork.Complete();
                        return Json(new { status = true, mess = "Thêm thành công " });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, mess = "Có lỗi xảy ra: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Del(int role, int id)
        {
            if (CookiesManage.GetUser().RoleId != RoleKey.Admin)
            {
                return Json(new { status = false, mess = "Bạn không có quyền" });
            }
            try
            {
                if (role == RoleKey.Teacher)
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        var elm = unitofwork.TeacherSubjects.Get(id);
                        if (elm != null)
                        {
                            unitofwork.TeacherSubjects.Remove(elm);
                            unitofwork.Complete();
                            return Json(new { status = true, mess = "Xóa thành công " });
                        }
                        else
                        {
                            return Json(new { status = false, mess = "Không tồn tại " });
                        }
                    }
                }
                else if (role == RoleKey.Student)
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        var elm = unitofwork.StudentSubjects.Get(id);
                        if (elm != null)
                        {
                            unitofwork.StudentSubjects.Remove(elm);
                            unitofwork.Complete();
                            return Json(new { status = true, mess = "Xóa thành công " });
                        }
                        else
                        {
                            return Json(new { status = false, mess = "Không tồn tại " });
                        }
                    }
                }
                else
                {
                    return Json(new { status = false, mess = "Bạn không có quyền" });
                }
            }
            catch
            {
                return Json(new { status = false, mess = "Thất bại" });
            }
        }
    }
}