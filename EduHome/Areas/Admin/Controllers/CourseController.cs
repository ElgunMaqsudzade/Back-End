using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static EduHome.Extensions.Extension;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public CourseController(UserManager<AppUser> userManager, AppDbContext db, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<CourseSimple> courseSimples = await _db.CourseSimples.Where(e => e.IsDeleted == false).Skip(0).Take(10).ToListAsync();
            return View(courseSimples);
        }
        public async Task<IActionResult> Detail(int id)
        {
            CourseSimple courseSimple = await _db.CourseSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.CourseDetail).ThenInclude(t => t.CourseFeature).FirstOrDefaultAsync();
            return View(courseSimple);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseForCreateVM course)
        {
            //We have int CourseSimpleId at CourseDetail for one for one relation we should either 
            //do that nullable or just do not use (!ModelState.Isvalid)

            //if (!ModelState.IsValid) return View();

            bool isExist = _db.BlogSimples.Where(c => c.IsDeleted == false).Any(c => c.Title.Trim().ToLower() == course.CourseSimple.Title.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Category already exist");
                return View();
            }
            if (course.CourseSimple.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View();
            }
            if (!course.CourseSimple.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View();
            }
            if (!course.CourseSimple.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View();
            }

            string folder = Path.Combine("img", "course");
            string fileName = await course.CourseSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            course.CourseSimple.Image = fileName;

            course.CourseSimple.CreateTime = DateTime.UtcNow;
            await _db.CourseSimples.AddAsync(course.CourseSimple);
            await _db.SaveChangesAsync();

            course.CourseDetail.CourseSimpleId = course.CourseSimple.Id;
            await _db.CourseDetails.AddAsync(course.CourseDetail);
            await _db.SaveChangesAsync();

            course.CourseFeature.CourseDetailId = course.CourseDetail.Id;
            await _db.CourseFeatures.AddAsync(course.CourseFeature);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            CourseSimple courseSimple = _db.CourseSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            return Json(courseSimple);
        }
        public async Task<IActionResult> DeleteCourse(int id)
        {
            CourseSimple courseSimple = _db.CourseSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            courseSimple.IsDeleted = true;
            await _db.SaveChangesAsync();
            return Json(courseSimple);
        }
        public async Task<IActionResult> Update(int id)
        {
            CourseSimple courseSimple = await _db.CourseSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.CourseDetail).ThenInclude(t => t.CourseFeature).FirstOrDefaultAsync();








            return View(courseSimple);
        }

    }
}
