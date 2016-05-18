using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Landau.Models.UserModel;

namespace Landau.Helper
{
    #region Email
    public class SendEmailHelper
    {

        /// <summary>
        /// Отправка письма на Email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="secondname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public static bool SendToEmail(string email, string firstname, string secondname, string lastname)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Credentials = new System.Net.NetworkCredential("landautesttest@gmail.com", "19940920alexkuchik111");
                smtpServer.Port = 587; // Gmail works on this port
                smtpServer.EnableSsl = true;
                mail.From = new MailAddress("landautesttest@gmail.com");
                mail.To.Add("alexkuchik.AK@gmail.com");
                mail.Subject = "Hello";
                mail.Body = "Hello" + " " + lastname + " " + " " + firstname + " " + " " + secondname;
                smtpServer.Send(mail);

                return true;
            }
            catch (Exception exception)
            {
                Log.AddLog("Error: " + exception.Message + "; InnerException: ");
                return false;
            }
        }
        public static bool SendToEmail(UserModel userModel)
        {
            try
            {
                var fileproperty = DocumentHelper.GetFileName(userModel.DocumentId);

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Credentials = new System.Net.NetworkCredential("landautesttest@gmail.com", "19940920alexkuchik111");
                smtpServer.Port = 587; // Gmail works on this port
                smtpServer.EnableSsl = true;
                mail.From = new MailAddress("landautesttest@gmail.com");
                mail.To.Add("alexkuchik.AK@gmail.com");
                mail.Subject = "Уведомление";
                mail.Body = "Здравствуйте," + " " + userModel.FirstName + " " + userModel.SecondName + " " + userModel.LastName + ".К загруженному вами файлу " + " " + fileproperty.FileName + " в проекте под номером " + fileproperty.ProjectId + " добавлен комментарий.";
                smtpServer.Send(mail);

                return true;
            }
            catch (Exception exception)
            {
                Log.AddLog("Error: " + exception.Message + "; InnerException: ");
                return false;
            }
        }
        public static bool SendToEmail(int documentid, int getuser)
        {
            try
            {
                var fileproperty = DocumentHelper.GetFileName(documentid);
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Credentials = new System.Net.NetworkCredential("landautesttest@gmail.com", "19940920alexkuchik111");
                smtpServer.Port = 587; // Gmail works on this port
                smtpServer.EnableSsl = true;
                mail.From = new MailAddress("landautesttest@gmail.com");
                mail.To.Add("alexkuchik.AK@gmail.com");
                mail.Subject = "Уведомление";
                mail.Body = "К файлу " + " " + fileproperty.FileName + " в проекте под номером " + fileproperty.ProjectId + " добавлен комментарий.";
                smtpServer.Send(mail);
                return true;
            }
            catch (Exception exception)
            {
                Log.AddLog("Error: " + exception.Message + "; InnerException: ");
                return false;
            }
        }
    }
    #endregion
}