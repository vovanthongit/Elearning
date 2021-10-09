using BELibrary.Entity;
using ELearning.Areas.Admin.Authorization;
using System;
using System.Web.Mvc;

namespace ELearning.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: /Administrator/Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!CookiesManage.Logined())
            {
                var returnUrl = filterContext.HttpContext.Request.RawUrl;
                filterContext.Result =
                new RedirectResult(String.Concat("~/Admin/Login/Index", "?ReturnUrl=", returnUrl));
            }
            base.OnActionExecuting(filterContext);
        }

        public static User GetCurrentUser()
        {
            return CookiesManage.GetUser();
        }
    }
}