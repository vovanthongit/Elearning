using BELibrary.Entity;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace BELibrary.Utils
{
    public class AccountUtils
    {
        protected static string Generatekey()
        {
            string key = "SHOP";
            for (int i = 0; i < 5; i++)
            {
                String s = CodeUtils.RandomString(4);
                Thread.Sleep(50);
                key += "-" + s;
            }
            return key;
        }

        public static ResponseEmail SendEmail(User account)
        {
            if (account != null)
            {
                string code = Generatekey();
                try
                {
                    var client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        UseDefaultCredentials = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials =
                            new NetworkCredential(
                                "nguyenthuha11071996@gmail.com",
                                "hahillgautruc1107"),
                        EnableSsl = true,
                    };
                    var from = new MailAddress("nguyenthuha11071996@gmail.com", "Admin Cửa hàng điện thoại Minh Anh");
                    var to = new MailAddress(account.Email);
                    var mail = new MailMessage(from, to)
                    {
                        Subject = "Xác thực tài khoản",
                        Body = "Xin chào " + account.FullName + "<br/> Chúng tôi đã gửi cho bạn 1 mã để bạn xác thự email của bạn <br/> Đây là mã xác thực Email : <h3><b> <span>" + code + "  </span></b></h3> Vui lòng coppy và quay lại trang đăng kí để xác thực",
                        IsBodyHtml = true,
                    };
                    client.Send(mail);

                    return new ResponseEmail(true, code);
                    // phải làm cái này ở mail dùng để gửi phải bật lên
                    // https://www.google.com/settings/u/1/security/lesssecureapps
                }
                catch (Exception)
                {
                    return new ResponseEmail(false, code);
                }
            }
            return new ResponseEmail(false, "");
        }
    }

    public class ResponseEmail
    {
        public bool Status { get; set; }
        public string Code { get; set; }

        public ResponseEmail(bool status, string code)
        {
            this.Status = status;
            this.Code = code;
        }
    }
}