using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public ContactController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
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
        public async Task<IActionResult> AddSubscriber(string email, string username)
        {
            if (email != null)
            {

                bool isExist = _db.Subscribers.Any(c => c.Mail == email);
                if (!isExist)
                {
                    Subscriber subscriber = new Subscriber()
                    {
                        Mail = email
                    };
                    await _db.Subscribers.AddAsync(subscriber);
                    await _db.SaveChangesAsync();
                    return Content("Subscribed");
                }
                else
                {
                    return Content("There is already Email like this");
                }


            }
            else
            {
                AppUser user = await _userManager.FindByNameAsync(username);

                bool isExist = _db.Subscribers.Any(c => c.Mail == user.Email);
                if (!isExist)
                {
                    Subscriber subscriber = new Subscriber()
                    {
                        Mail = user.Email
                    };
                    await _db.Subscribers.AddAsync(subscriber);
                    await _db.SaveChangesAsync();

                    return Content("Subscribed");
                }
                else
                {
                    return Content("There is already Email like this");
                }
            }
        }
        public async Task<IActionResult> Comment(string subject, string message, string name, string email)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    name = user.Fullname;
                    email = user.Email;
                }
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("imbackend4000@gmail.com", "backend318");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mailMessage = new MailMessage("imbackend4000@gmail.com", "elgun.maqsudzade@gmail.com");
                mailMessage.Subject = $"Message From Client";
                mailMessage.Body = $"Client Subject - {subject} <br> Client Name - {name} <br> Client Email - {email} <br> Client Message - {message}";
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);

                return Json(new { send = true });
            }
            catch (Exception)
            {
                return Json(new { send = false });
                throw;
            }
        }
    }
}
