using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
