using BELibrary.Core.Entity;
using BELibrary.Entity;
using BELibrary.Utils;
using System;
using System.Web;

namespace ELearning.Areas.Admin.Authorization
{
    public class CookiesManage
    {
        public static bool Logined()
        {
            var cookiesClient = HttpContext.Current.Request.Cookies.Get("name_client");
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
            var cookiesClient = HttpContext.Current.Request.Cookies.Get("name_client");
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