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
    [Authorize(Roles = "Admin, CourseModerator")]
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
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.CourseSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();

            CourseSimple courseSimple = await _db.CourseSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.CourseDetail).ThenInclude(t => t.CourseFeature).FirstOrDefaultAsync();
            return View(courseSimple);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseForCreateVM course, List<int> Tags, int Category)
        {
            //We have int CourseSimpleId at CourseDetail for one for one relation we should either 
            //do that nullable or just do not use (!ModelState.Isvalid)

            //if (!ModelState.IsValid) return View();
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();

            bool isExist = _db.CourseSimples.Where(c => c.IsDeleted == false).Any(c => c.Title.Trim().ToLower() == course.CourseSimple.Title.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Course already exist");
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
            course.CourseSimple.CategoryId = Category;

            course.CourseSimple.CreateTime = DateTime.UtcNow;
            await _db.CourseSimples.AddAsync(course.CourseSimple);
            await _db.SaveChangesAsync();

            foreach (int id in Tags)
            {
                await _db.TagCourseSimples.AddAsync(new TagCourseSimple { CourseSimpleId = course.CourseSimple.Id, TagId = id });
            }

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
        public async Task<IActionResult> DeletePost(int id)
        {
            CourseSimple courseSimple = _db.CourseSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            courseSimple.IsDeleted = true;
            courseSimple.DeleteTime = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return Json(courseSimple);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.CourseSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();
            CourseForCreateVM courseForCreateVM = new CourseForCreateVM()
            {
                CourseSimple = await _db.CourseSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.CourseDetail).ThenInclude(t => t.CourseFeature).FirstOrDefaultAsync(),
                CourseDetail = await _db.CourseDetails.Where(e => e.CourseSimpleId == id).Include(t => t.CourseFeature).FirstOrDefaultAsync(),
                CourseFeature = await _db.CourseFeatures.Where(e => e.CourseDetail.CourseSimpleId == id).FirstOrDefaultAsync(),
                Categories = await _db.Categories.ToListAsync(),
                Tags = await _db.Tags.ToListAsync(),
            };
            return View(courseForCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CourseForCreateVM course,List<int> Tags,int Category)
        {
            //We have int CourseSimpleId at CourseDetail for one for one relation we should either 
            //do that nullable or just do not use (!ModelState.Isvalid)
            CourseForCreateVM courseForCreateVM = new CourseForCreateVM()
            {
                CourseSimple = await _db.CourseSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.CourseDetail).ThenInclude(t => t.CourseFeature).FirstOrDefaultAsync(),
                CourseDetail = await _db.CourseDetails.Where(e => e.CourseSimpleId == id).Include(t => t.CourseFeature).FirstOrDefaultAsync(),
                CourseFeature = await _db.CourseFeatures.Where(e => e.CourseDetail.CourseSimpleId == id).FirstOrDefaultAsync(),
                Categories = await _db.Categories.ToListAsync(),
                Tags = await _db.Tags.ToListAsync(),
            };

            bool isExist = _db.CourseSimples.Where(c => c.IsDeleted == false).Any(c => c.Title.Trim().ToLower() == course.CourseSimple.Title.Trim().ToLower() && c.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("", "This Course already exist");
                return View(courseForCreateVM);
            }
            if (course.CourseSimple.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View(courseForCreateVM);
            }
            if (!course.CourseSimple.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View(courseForCreateVM);
            }
            if (!course.CourseSimple.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View(courseForCreateVM);
            }

            string folder = Path.Combine("img", "course");
            string fileName = await course.CourseSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);

            CourseSimple courseSimple = await _db.CourseSimples.Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefaultAsync();
            CourseDetail courseDetail = await _db.CourseDetails.Where(c => c.CourseSimpleId == id).FirstOrDefaultAsync();
            CourseFeature courseFeature = await _db.CourseFeatures.Where(c => c.CourseDetail.CourseSimpleId == id).FirstOrDefaultAsync();

            courseSimple.CategoryId = Category;
            courseSimple.Image = fileName;
            courseSimple.Title = course.CourseSimple.Title;
            courseSimple.MainContent = course.CourseSimple.MainContent;
            courseSimple.IsSimple = course.CourseSimple.IsSimple;
            courseSimple.UpdateTime = DateTime.UtcNow;
            courseDetail.AboutCourse = course.CourseDetail.AboutCourse;
            courseDetail.ApplyContent = course.CourseDetail.ApplyContent;
            courseDetail.CertificationContent = course.CourseDetail.CertificationContent;
            courseFeature.StartingTime = course.CourseFeature.StartingTime;
            courseFeature.StudentCount = course.CourseFeature.StudentCount;
            courseFeature.SkillLevel = course.CourseFeature.SkillLevel;
            courseFeature.Price = course.CourseFeature.Price;
            courseFeature.Language = course.CourseFeature.Language;
            courseFeature.Assesment = course.CourseFeature.Assesment;
            courseFeature.CourseDuration = course.CourseFeature.CourseDuration;
            courseFeature.ClassDuration = course.CourseFeature.ClassDuration;

            await _db.SaveChangesAsync();


            foreach (var i in Tags)
            {
                _db.TagCourseSimples.Add(new TagCourseSimple { CourseSimpleId = courseSimple.Id, TagId = i });
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
