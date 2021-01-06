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
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _db.Sliders.ToListAsync();
            return View(sliders);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Sliders.Any(c => c.Id == id);
            if (!isExist) return NotFound();

            Slider slider = await _db.Sliders.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(slider);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {

            if (!ModelState.IsValid) return View();

            if (slider.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View();
            }
            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View();
            }
            if (!slider.Photo.MaxSize(1000))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 1000");
                return View();
            }

            string folder = Path.Combine("img", "slider");
            string fileName = await slider.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            slider.Image = fileName;

            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Sliders.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            Slider slider = await _db.Sliders.Where(c => c.Id == id).FirstOrDefaultAsync();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Slider slider)
        {

            Slider slider1 = await _db.Sliders.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (!ModelState.IsValid) return View(slider1);

            if (slider.Photo != null)
            {
                if (!slider.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please,add Image file");
                    return View(slider1);
                }
                if (!slider.Photo.MaxSize(500))
                {
                    ModelState.AddModelError("", "Max size of Image should be lower than 500");
                    return View(slider1);
                }
                string folder = Path.Combine("img", "slider");
                string fileName = await slider.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                string path = Path.Combine(_env.WebRootPath, folder, slider1.Image);
                slider1.Image = fileName;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }


            slider1.Title = slider.Title;
            slider1.Description = slider.Description;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _db.Sliders.Where(e => e.Id == id).FirstOrDefault();
            return Json(slider);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            List<Slider> slider = _db.Sliders.Where(e => e.Id == id).ToList();
            if(slider.Count() > 0)
            {
                _db.Sliders.Remove(slider.FirstOrDefault());
                string folder = Path.Combine("img", "blog");
                string path = Path.Combine(_env.WebRootPath, folder, slider.FirstOrDefault().Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            else
            {
                return NotFound();
            }
            await _db.SaveChangesAsync();
            return Json(slider);
        }
    }
}
