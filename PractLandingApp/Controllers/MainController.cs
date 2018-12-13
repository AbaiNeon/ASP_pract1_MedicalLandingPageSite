using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PractLandingApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void SendData(string mail)
        {
            //return View("index");
            
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(mail, "Abai");
            // кому отправляем
            MailAddress to = new MailAddress(mail);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тема";
            // текст письма
            m.Body = "Вы подписались на новости";
            // письмо представляет код html
            m.IsBodyHtml = false;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            // логин и пароль
            string password = "";
            smtp.Credentials = new NetworkCredential(mail, password);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
