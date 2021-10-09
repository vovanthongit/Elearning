using System.Collections.Generic;
using System.Linq;

namespace BELibrary.Utils
{
    public static class SessionKey
    {
        public const string User = "user";
        public const string RegUser = "RegUser";
        public const string Admin = "admin";
    }

    public static class FileKey
    {
        public const int MaxLength = 1024 * 1000;
        public const int MaxTestLength = 1024 * 6000;

        public static List<string> FileTestExtensionApprove()
        {
            return new List<string>(new[] { "doc", "docx", "pdf", "txt", "rtf" });
        }

        public static List<string> FileExtensionApprove()
        {
            return new List<string>(new[] { "png", "jpg", "jpeg" });
        }

        public static List<string> FileContentTypeApprove()
        {
            return new List<string>(new string[]
            {
                "application/pdf",
                "application/vnd.ms-excel",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            });
        }
    }

    public static class CookiesKey
    {
        public const string LangCode = "lang_code";
        public const string Username = "name_client";
    }

    public static class LangCode
    {
        public const string English = "en";
        public const string VietNam = "vi";
        public const string Japan = "ja";
        public const string Default = "en";

        public static string GetText(string code)
        {
            switch (code)
            {
                case "en":
                    return "English";

                case "vi":
                    return "Việt Nam";

                case "ja":
                    return "Japan";

                default:
                    return "Unknown";
            }
        }

        public static List<string> GetList()
        {
            return new List<string>(new string[] { "en", "vi", "ja" });
        }

        public static List<SelectListModel> GetDic()
        {
            return new List<SelectListModel>() {
                new SelectListModel{Key="vi",Value="Tiếng Việt" },
                new SelectListModel{Key="en",Value="Tiếng Anh" },
                new SelectListModel{Key="ja",Value="Tiếng Nhật" }
            };
        }
    }

    public static class Facebook
    {
        public static List<SelectListModel> GetOGTypeDic()
        {
            return new List<SelectListModel>() {
                new SelectListModel{Key="website",Value="website" },
                new SelectListModel{Key="article",Value="article" },
                new SelectListModel{Key="profile",Value="profile" },
                new SelectListModel{Key="place",Value="place" },
                new SelectListModel{Key="product",Value="product" }
            };
        }
    }

    public static class RoleKey
    {
        public const int Admin = 1;
        public const int Teacher = 2;
        public const int Student = 3;

        public static List<int> GetList()
        {
            return new List<int>(new int[] { 1, 2, 3 });
        }

        public static bool Any(int role)
        {
            return GetList().Any(x => x == role);
        }

        public static string GetRole(int role)
        {
            switch (role)
            {
                case 1:
                    return "Admin";

                case 2:
                    return "Teacher";

                case 3:
                    return "Student";

                default:
                    return "Unknown";
            }
        }

        public static string GetRoleText(int role)
        {
            switch (role)
            {
                case 1:
                    return "Quản trị";

                case 2:
                    return "Giáo viên";

                case 3:
                    return "Học sinh";

                default:
                    return "Unknown";
            }
        }

        public static List<SelectListModel> GetDic()
        {
            return new List<SelectListModel>() {
                new SelectListModel{Key=1,Value="Quản trị" },
                new SelectListModel{Key=2,Value="Giáo viên" },
                new SelectListModel{Key=3,Value="Học sinh" }
            };
        }
    }

    public static class GenderKey
    {
        public const int Male = 1;
        public const int FeMale = 0;

        public static List<SelectListModel> GetDic()
        {
            return new List<SelectListModel>() {
                new SelectListModel{Key=1,Value="Nam" },
                new SelectListModel{Key=0,Value="Nữ" }
            };
        }

        public static string GetEmployeeType(int type)
        {
            switch (type)
            {
                case 0:
                    return "Nữ";

                case 1:
                    return "Nam";

                default:
                    return "Unknown";
            }
        }
    }

    public static class VariableExtensions
    {
        public static int pageSize = 2;

        public static string KeyCryptor = "Phucnd#2020";

        public static string DefautlPassword = "123qwe";
    }

    public static class StatusRegSubject
    {
        public const int Approve = 1;
        public const int Pending = 0;
        public const int Reject = -1;

        public static List<int> GetList()
        {
            return new List<int>(new int[] { 1, 0, -1 });
        }

        public static bool Any(int stt)
        {
            return GetList().Any(x => x == stt);
        }

        public static string GetRole(int stt)
        {
            switch (stt)
            {
                case 1:
                    return "Approve";

                case 0:
                    return "Pending";

                case -1:
                    return "Reject";

                default:
                    return "Unknown";
            }
        }

        public static string GetRoleText(int stt)
        {
            switch (stt)
            {
                case 1:
                    return "Đã duyệt";

                case 0:
                    return "Đang chờ";

                case -1:
                    return "Từ chối";

                default:
                    return "Unknown";
            }
        }

        public static List<SelectListModel> GetDic()
        {
            return new List<SelectListModel>() {
                new SelectListModel{Key=1,Value="Quản trị" },
                new SelectListModel{Key=2,Value="Giáo viên" },
                new SelectListModel{Key=3,Value="Học sinh" }
            };
        }
    }

    public static class RateKey
    {
        public static List<double> GetList()
        {
            return new List<double>(new double[] { 0, 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5 });
        }

        public static bool Any(double el)
        {
            return GetList().Any(x => x == el);
        }

        public static string GetRole(int stt)
        {
            switch (stt)
            {
                case 1:
                    return "Approve";

                case 0:
                    return "Pending";

                case -1:
                    return "Reject";

                default:
                    return "Unknown";
            }
        }

        public static string GetRoleText(int stt)
        {
            switch (stt)
            {
                case 1:
                    return "Đã duyệt";

                case 0:
                    return "Đang chờ";

                case -1:
                    return "Từ chối";

                default:
                    return "Unknown";
            }
        }

        public static List<SelectListModel> GetDic()
        {
            return new List<SelectListModel>() {
                new SelectListModel{Key=1,Value="Quản trị" },
                new SelectListModel{Key=2,Value="Giáo viên" },
                new SelectListModel{Key=3,Value="Học sinh" }
            };
        }
    }

    public enum StatusCode
    {
        Success = 200,
        NotFound = 404,
        NotForbidden = 403,
        ServerError = 500
    }

    public class SelectListModel
    {
        public object Key { get; set; }
        public string Value { get; set; }
    }
}