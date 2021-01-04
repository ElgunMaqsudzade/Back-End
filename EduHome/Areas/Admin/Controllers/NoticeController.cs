using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static EduHome.Extensions.Extension;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NoticeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public NoticeController(UserManager<AppUser> userManager, AppDbContext db, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Update()
        {
            AboutArea aboutArea = await _db.AboutAreas.FirstOrDefaultAsync();
            return View(aboutArea);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutArea about)
        {
            AboutArea aboutArea = await _db.AboutAreas.FirstOrDefaultAsync();

            if (about.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View();
            }
            if (!about.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View();
            }
            if (!about.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View();
            }

            string folder = Path.Combine("img", "about");
            string fileName = await about.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            string path = Path.Combine(_env.WebRootPath, folder, aboutArea.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            aboutArea.Image = fileName;
            aboutArea.Title = about.Title;
            aboutArea.Description = about.Description;
            aboutArea.UpdateTime = DateTime.UtcNow;

            await _db.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
