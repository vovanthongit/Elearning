using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BELibrary.Utils;

namespace ELearning.Areas.Admin.Authorization
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 1. Admin
        /// 2. Employee
        /// 3. Customer
        /// </summary>
        public int Role { set; get; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!CookiesManage.Logined())
            {
                return false;
            }

            var user = CookiesManage.GetUser();
            if (user == null) return false;
            return this.Role == user.RoleId || user.RoleId == RoleKey.Admin;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var TempData = filterContext.Controller.TempData;
            TempData["Messages"] = "Bạn không có quyền truy cập mục này";
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "action", "E401" },
                    { "controller", "Dashboard" },
                    { "Area", "Admin" }
                });
        }
    }
}