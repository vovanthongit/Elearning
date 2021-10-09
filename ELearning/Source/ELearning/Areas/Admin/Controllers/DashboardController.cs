using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web.Mvc;
using BELibrary.Core.Entity;
using BELibrary.Entity;
using BELibrary.Utils;
using ELearning.Areas.Admin.Models;

namespace ELearning.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            var user = GetCurrentUser();
            using (var workScope = new UnitOfWork(new ELearningDBContext()))
            {
                if (user.RoleId == RoleKey.Admin)
                {
                    var regStudent = workScope.StudentSubjects.GetAll().ToList();
                    var subjects = workScope.Subjects.GetAll().ToList();
                    var lectures = workScope.Lectures.GetAll().ToList();
                    var comments = workScope.Comments.GetAll().ToList();

                    //
                    ViewBag.RegStudentCount = regStudent.Count;
                    ViewBag.SubjectCount = subjects.Count;
                    ViewBag.LectureCount = lectures.Count;
                    ViewBag.CommentCount = comments.Count;

                    var now = DateTime.Now;
                    //
                    ViewBag.RegStudentTodayCount = regStudent.Count(x => x.CreatedDate.Day == now.Day && x.CreatedDate.Month == now.Month && x.CreatedDate.Year == now.Year);
                    ViewBag.RegStudentMonthCount = regStudent.Count(x => x.CreatedDate.Month == now.Month && x.CreatedDate.Year == now.Year);

                    ViewBag.SubjectTodayCount = subjects.Count(x => x.ModifiedDate.Day == now.Day && x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);
                    ViewBag.SubjectMonthCount = subjects.Count(x => x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);

                    ViewBag.LectureTodayCount = lectures.Count(x => x.ModifiedDate.Day == now.Day && x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);
                    ViewBag.LectureMonthCount = lectures.Count(x => x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);

                    ViewBag.CommentTodayCount = comments.Count(x => x.Time.Day == now.Day && x.Time.Month == now.Month && x.Time.Year == now.Year);
                    ViewBag.CommentMonthCount = comments.Count(x => x.Time.Month == now.Month && x.Time.Year == now.Year);

                    // new patient

                    var studentSubjects = workScope.StudentSubjects.GetAll().OrderByDescending(x => x.CreatedDate).Take(6).ToList();

                    var users = workScope.Account.GetAll();
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
                    ViewBag.StudentSubjects = listData.ToList();
                    return View("Admin");
                }
                else
                {
                    var subjectAssign =
                        workScope.TeacherSubjects.Query(x => x.Username.ToLower() == user.Username.ToLower());

                    var subjects = workScope.Subjects.GetAll().Join(
                        subjectAssign,
                        sj => sj.Id,
                        sja => sja.SubjectId,
                        (sj, sja) => new { sj }).Select(x => x.sj).Where(x => x.Status).ToList();

                    var regStudent = workScope.StudentSubjects.GetAll().Join(
                        subjects,
                        sjr => sjr.SubjectId, //Student Subjects reg
                        sj => sj.Id,
                        (sjr, sj) => new { sjr }).Select(x => x.sjr).ToList();

                    var lectures = workScope.Lectures.GetAll().Join(
                        subjects,
                        l => l.SubjectId,
                        sj => sj.Id,
                        (l, sj) => new { l }).Select(x => x.l).ToList();

                    var comments = workScope.Comments.GetAll().Join(
                        lectures,
                        c => c.LectureId,
                        l => l.Id,
                        (c, l) => new { c }).Select(x => x.c).ToList();
                    //
                    ViewBag.RegStudentCount = regStudent.Count;
                    ViewBag.SubjectCount = subjects.Count;
                    ViewBag.LectureCount = lectures.Count;
                    ViewBag.CommentCount = comments.Count;

                    var now = DateTime.Now;
                    //
                    ViewBag.RegStudentTodayCount = regStudent.Count(x => x.CreatedDate.Day == now.Day && x.CreatedDate.Month == now.Month && x.CreatedDate.Year == now.Year);
                    ViewBag.RegStudentMonthCount = regStudent.Count(x => x.CreatedDate.Month == now.Month && x.CreatedDate.Year == now.Year);

                    ViewBag.SubjectTodayCount = subjects.Count(x => x.ModifiedDate.Day == now.Day && x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);
                    ViewBag.SubjectMonthCount = subjects.Count(x => x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);

                    ViewBag.LectureTodayCount = lectures.Count(x => x.ModifiedDate.Day == now.Day && x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);
                    ViewBag.LectureMonthCount = lectures.Count(x => x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);

                    ViewBag.CommentTodayCount = comments.Count(x => x.Time.Day == now.Day && x.Time.Month == now.Month && x.Time.Year == now.Year);
                    ViewBag.CommentMonthCount = comments.Count(x => x.Time.Month == now.Month && x.Time.Year == now.Year);

                    // new patient

                    ViewBag.Lectures = lectures.Take(6).ToList();
                    return View("Teacher");
                }
            }
        }

        public ActionResult E401()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetRegByYear(int year)
        {
            var user = GetCurrentUser();
            using (var workScope = new UnitOfWork(new ELearningDBContext()))
            {
                List<StudentSubject> studentSubjects;

                if (user.RoleId == RoleKey.Admin)
                {
                    studentSubjects = workScope.StudentSubjects.GetAll().ToList();
                }
                else
                {
                    var subjectAssign =
                        workScope.TeacherSubjects.Query(x => x.Username.ToLower() == user.Username.ToLower());

                    var subjects = workScope.Subjects.GetAll().Join(
                        subjectAssign,
                        sj => sj.Id,
                        sja => sja.SubjectId,
                        (sj, sja) => new { sj }).Select(x => x.sj).Where(x => x.Status).ToList();

                    studentSubjects = workScope.StudentSubjects.GetAll().Join(
                        subjects,
                        sjr => sjr.SubjectId, //Student Subjects reg
                        sj => sj.Id,
                        (sjr, sj) => new { sjr }).Select(x => x.sjr).ToList();
                }

                var date = new DateTime(year, 1, 1);
                var months = Enumerable.Range(0, 12)
                    .Select(x => new
                    {
                        month = date.AddMonths(x).Month,
                        year = date.AddMonths(x).Year
                    }).ToList();

                var dataPerYearAndMonth =
                    months.GroupJoin(studentSubjects,
                        m => new { m.month, m.year },
                        patient => new
                        {
                            month = patient.CreatedDate.Month,
                            year = patient.CreatedDate.Year
                        },
                        (p, g) => new
                        {
                            month = "Tháng " + p.month,
                            p.year,
                            count = g.Count()
                        });

                return
                    Json(new
                    {
                        status = true,
                        mess = "Thành công ",
                        data = dataPerYearAndMonth.ToList()
                    });
            }
        }

        //[HttpPost]
        //public JsonResult GetItemByCategory(Guid? categoryId)
        //{
        //    if (!categoryId.HasValue)
        //    {
        //        return
        //            Json(new
        //            {
        //                status = false,
        //                mess = "Danh mục không tồn tại"
        //            });
        //    }
        //    using (var workScope = new UnitOfWork(new ELearningDBContext()))
        //    {
        //        var amountItem = workScope.Items.Query(x => x.CategoryId == categoryId).Sum(item => item.Amount);

        //        var supplies = workScope.MedicalSupplies.Include(x => x.Item).Where(x => x.Item.CategoryId == categoryId).ToList();

        //        var hireCount = supplies.Where(x => x.Status == StatusMedical.Hired).Sum(x => x.Amount);
        //        var availabilityCount = supplies.Where(x => x.Status == StatusMedical.Availability).Sum(x => x.Amount);
        //        var expiredCount = supplies.Where(x => x.Status == StatusMedical.Expired).Sum(x => x.Amount);
        //        var unavailableCount = supplies.Where(x => x.Status == StatusMedical.Unavailable).Sum(x => x.Amount);
        //        var maintenanceCount = supplies.Where(x => x.Status == StatusMedical.Maintenance).Sum(x => x.Amount);

        //        var availabilityItem = amountItem - hireCount - expiredCount - unavailableCount - maintenanceCount;

        //        return
        //            Json(new
        //            {
        //                status = true,
        //                mess = "Thành công ",
        //                data = new[]
        //                {
        //                    new
        //                    {
        //                        label = "Đã sử dụng", value = hireCount
        //                    },
        //                    new
        //                    {
        //                        label = "Khả dụng", value = availabilityItem
        //                    },
        //                    new
        //                    {
        //                        label = "Không khả dụng", value = unavailableCount
        //                    },
        //                    new
        //                    {
        //                        label = "Bảo trì", value = maintenanceCount
        //                    },
        //                    new
        //                    {
        //                        label = "Hết Hạn", value = expiredCount
        //                    }
        //                }
        //            });
        //    }
        //}
    }
}