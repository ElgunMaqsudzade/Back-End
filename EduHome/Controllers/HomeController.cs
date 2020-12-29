using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                EventSimples = _db.EventSimples.Where(e => e.IsDeleted == false).Take(4).ToList(),
                HomeSliders = _db.HomeSliders.Take(3).ToList(),
                TeacherSimples = _db.TeacherSimples.Where(e => e.IsDeleted == false).Include(t=>t.TeacherDetail).Take(3).ToList(),
            };
            return View(homeVM);
        }
    }
}