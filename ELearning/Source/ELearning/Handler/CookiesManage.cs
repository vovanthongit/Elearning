using BELibrary.Core.Entity;
using BELibrary.Entity;
using BELibrary.Utils;
using System;
using System.Linq;
using System.Web;

namespace ELearning.Handler
{
    public class CookiesManage
    {
        public static bool CheckLanguageCode()
        {
            var cookiesClientLangCode = HttpContext.Current.Request.Cookies.Get(CookiesKey.LangCode);
            if (cookiesClientLangCode != null)
            {
                if (LangCode.GetList().Any(x => x == cookiesClientLangCode.Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string GetLanguageCode()
        {
            if (CheckLanguageCode())
            {
                return HttpContext.Current.Request.Cookies.Get(CookiesKey.LangCode).Value;
            }
            else
            {
                return LangCode.Default;
            }
        }
        public static bool Logined()
        {
            var cookiesClient = HttpContext.Current.Request.Cookies.Get("name_student");
            if (cookiesClient != null)
            {
                var decodeCookie = CryptorEngine.Decrypt(cookiesClient.Value, true);
                var unitOfWork = new UnitOfWork(new ELearningDBContext());
                var us = unitOfWork.Account.GetAccountByUsername(decodeCookie);
                if (us != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static User GetUser()
        {
            var cookiesClient = HttpContext.Current.Request.Cookies.Get("name_student");
            if (cookiesClient != null)
            {
                var decodeCookie = CryptorEngine.Decrypt(cookiesClient.Value, true);
                var unitOfWork = new UnitOfWork(new ELearningDBContext());
                var us = unitOfWork.Account.GetAccountByUsername(decodeCookie);
                if (us != null)
                {
                    return us;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //clear all session
        public static void ClearAll()
        {
            HttpContext.Current.Session.RemoveAll();
        }
    }
}