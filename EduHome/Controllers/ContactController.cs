using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ContactVM contactVM = new ContactVM()
            {
                Contacts = _db.Contacts.ToList(),
                MapAddress = _db.MapAddresses.FirstOrDefault(),
            };
            return View(contactVM);
        }
        //public IActionResult SendEmail(string subject,string body, string name,string email)
        //{

        //    SmtpClient client = new SmtpClient("smtp.mail.ru", 587);
        //    client.UseDefaultCredentials = false;
        //    client.EnableSsl = true;
        //    client.Credentials = new NetworkCredential("back.end.00@mail.ru", "developer123");
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    MailMessage message = new MailMessage("back.end.00@mail.ru", email);
        //    message.Subject = "<By Default: IAP Choices Notification>";
        //    message.Body = "Hi, <Student_Name><br>Your choice for <Program Name> has been approved<br>";
        //    message.BodyEncoding = System.Text.Encoding.UTF8;
        //    message.IsBodyHtml = true;

        //    client.Send(message);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
