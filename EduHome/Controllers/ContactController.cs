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

    }
}
