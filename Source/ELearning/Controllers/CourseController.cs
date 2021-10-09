using BELibrary.Core.Entity;
using BELibrary.Entity;
using BELibrary.Utils;
using ELearning.Handler;
using ELearning.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELearning.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index(int? page)
        {
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var related = unitofwork.Courses.GetAll().OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
                ViewBag.Related = related;

                var items = unitofwork.Courses.GetAll().Select(x => new CourseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    Description = x.Description,
                });

                int pageNumber = (page ?? 1);
                int pageSize = 4;
                var result = items.ToPagedList(pageNumber, pageSize);

                foreach (var item in result)
                {
                    item.Rate = unitofwork.Rating.CalculatorRate(item.Id).Total * 2 * 10;
                }

                return View(result);
            }
        }

        public ActionResult Detail(int? id, int? page)
        {
            if (!id.HasValue)
            {
                return Redirect("/Home/e404");
            }
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var item = unitofwork.Courses.FirstOrDefault(x => x.Id == id);

                if (item == null)
                {
                    return Redirect("/Home/e404");
                }
                ViewBag.Rate = unitofwork.Rating.CalculatorRate(item.Id);

                double rateByUser = 0;
                if (CookiesManage.Logined())
                {
                    var user = CookiesManage.GetUser();
                    var rating = unitofwork.Rating.FirstOrDefault(x => x.CourseId == item.Id && x.Username == user.Username);
                    if (rating != null)
                    {
                        rateByUser = rating.Point;
                    }
                }

                NumberFormatInfo nfi = new NumberFormatInfo
                {
                    NumberDecimalSeparator = "."
                };

                ViewBag.RateByUser = rateByUser.ToString(nfi);

                var subjects = unitofwork.Subjects.Query(x => x.CourseId == id).ToList();

                int pageNumber = (page ?? 1);
                int pageSize = 6;

                ViewBag.Item = item;

                return View(subjects.ToPagedList(pageNumber, pageSize));
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult Rate(int courseId, double point)
        {
            if (CookiesManage.Logined())
            {
                if (courseId >= 1 && RateKey.Any(point))
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        var user = CookiesManage.GetUser();
                        var course = unitofwork.Courses.FirstOrDefault(x => x.Id == courseId);
                        if (course != null)
                        {
                            var rating = unitofwork.Rating.FirstOrDefault(x => x.CourseId == courseId && x.Username == user.Username);

                            if (rating != null)
                            {
                                rating.Point = point;
                                unitofwork.Rating.Put(rating, rating.Id);
                            }
                            else
                            {
                                var rate = new Rating
                                {
                                    CourseId = course.Id,
                                    Username = CookiesManage.GetUser().Username,
                                    Point = point
                                };
                                unitofwork.Rating.Add(rate);
                            }

                            unitofwork.Complete();
                            //xóa thành công
                            return Json(new { status = true, mess = $"Bạn đã xếp hạng: {point} sao cho khóa học: {course.Name}" });
                        }
                        else
                        {
                            return Json(new { status = false, mess = "course không tồn tại" });
                        }
                    }
                }
                else
                {
                    return Json(new { status = false, mess = "Lỗi dữ liệu" });
                }
            }
            else
            {
                return Json(new { status = false, mess = "Vui lòng đăng nhập" });
            }
        }

        public ActionResult Search(string keyword, int? page)
        {
            if (keyword == "")
            {
                keyword = null;
            }
            using (var workScope = new UnitOfWork(new ELearningDBContext()))
            {
                var listData = workScope.Courses.Query(x => x.Status).OrderByDescending(x => x.ModifiedDate).ToList();
                var q = from mt in listData
                        where (!string.IsNullOrEmpty(keyword) && mt.Name.ToLower().Contains(keyword.ToLower()))
                              || (!string.IsNullOrEmpty(keyword) && mt.Description.ToLower().Contains(keyword.ToLower()))
                              || (!string.IsNullOrEmpty(keyword) && mt.Content.ToLower().Contains(keyword.ToLower()))
                              || (!string.IsNullOrEmpty(keyword) && mt.Requirements.ToLower().Contains(keyword.ToLower()))
                              || (!string.IsNullOrEmpty(keyword) && mt.Benefits.ToLower().Contains(keyword.ToLower()))
                        select mt;

                var related = workScope.Courses.GetAll().OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
                ViewBag.Related = related;

                var items = q.Select(x => new CourseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    Description = x.Description,
                });

                var pageNumber = (page ?? 1);
                const int pageSize = 4;
                var result = items.ToPagedList(pageNumber, pageSize);

                foreach (var item in result)
                {
                    item.Rate = workScope.Rating.CalculatorRate(item.Id).Total * 2 * 10;
                }
                return View(result);
            }
        }
    }
}