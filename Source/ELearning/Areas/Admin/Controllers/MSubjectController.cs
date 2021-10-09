using BELibrary.Core.Entity;
using BELibrary.Entity;
using System;
using System.Linq;
using System.Web.Mvc;
using BELibrary.Utils;
using ELearning.Areas.Admin.Authorization;

namespace ELearning.Areas.Admin.Controllers
{
    [Permission(Role = RoleKey.Admin)]
    public class MSubjectController : BaseController
    {
        private readonly string keyElement = "Môn học";

        public ActionResult Index()
        {
            ViewBag.Element = keyElement;
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var listData = unitofwork.Subjects.GetAll().ToList();
                return View(listData);
            }
        }

        public ActionResult Create()
        {
            ViewBag.key = "Thêm mới";
            ViewBag.Element = keyElement;

            ViewBag.isEdit = false;

            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var courses = unitofwork.Courses.Query(x => x.Status).ToList();
                ViewBag.Courses = new SelectList(courses, "Id", "Name");
            }

            return View();
        }

        public ActionResult Update(int id)
        {
            ViewBag.isEdit = true;
            ViewBag.key = "Cập nhật";
            ViewBag.Element = keyElement;
            using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
            {
                var article = unitofwork.Subjects.FirstOrDefault(x => x.Id == id);

                var courses = unitofwork.Courses.Query(x => x.Status).ToList();
                ViewBag.Courses = new SelectList(courses, "Id", "Name");

                return View("Create", article);
            }
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Subject input, bool isEdit)
        {
            try
            {
                if (isEdit) //update
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        var elm = unitofwork.Subjects.Get(input.Id);
                        if (elm != null) //update
                        {
                            input.CreatedBy = elm.CreatedBy;
                            input.CreatedDate = elm.CreatedDate;
                            elm = input;
                            elm.ModifiedBy = GetCurrentUser().FullName;
                            elm.ModifiedDate = DateTime.Now;
                            unitofwork.Subjects.Put(elm, elm.Id);
                            unitofwork.Complete();
                            return Json(new { status = true, mess = "Cập nhập thành công" });
                        }
                        else
                        {
                            return Json(new { status = false, mess = "Không tồn tại " + keyElement });
                        }
                    }
                }
                else
                {
                    using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                    {
                        input.CreatedBy = GetCurrentUser().FullName;
                        input.CreatedDate = DateTime.Now;
                        input.ModifiedBy = GetCurrentUser().FullName;
                        input.ModifiedDate = DateTime.Now;
                        input.NumberStudent = 0;

                        unitofwork.Subjects.Add(input);

                        unitofwork.Complete();
                        return Json(new { status = true, mess = "Thêm thành công " + keyElement });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, mess = "Có lỗi xảy ra: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Del(int id)
        {
            try
            {
                using (var unitofwork = new UnitOfWork(new ELearningDBContext()))
                {
                    var elm = unitofwork.Subjects.Get(id);
                    if (elm != null) //update
                    {
                        unitofwork.Subjects.Remove(elm);
                        unitofwork.Complete();
                        return Json(new { status = true, mess = "Xóa thành công " + keyElement });
                    }
                    else
                    {
                        return Json(new { status = false, mess = "Không tồn tại " + keyElement });
                    }
                }
            }
            catch
            {
                return Json(new { status = false, mess = "Thất bại" });
            }
        }
    }
}