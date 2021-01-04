using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FiorelloLayout.DAL;
using FiorelloLayout.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloLayout.Areas.Admin.Controllers
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
        public IActionResult Index()
        {

            return View(_db.Sliders.ToList());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (slider.Photo == null)
            {
                return View();
            }
            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Type of file should be Image");
                return View();
            }
            if (slider.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "Size of file should be less then 300");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + slider.Photo.FileName;
            string path =Path.Combine(_env.WebRootPath, "img", fileName) ;
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(fileStream);
            }
            slider.Image = fileName;
            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "img", slider.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

             _db.Sliders.Remove(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Slider sliderD = await _db.Sliders.FindAsync(id);
            if (sliderD == null) return NotFound();
            return View(sliderD);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public async Task<IActionResult> UpdatePost(int? id, Slider slider)
        {


            Slider sliderD = await _db.Sliders.FindAsync(id);
            if (id == null) return NotFound();
            if (slider.Photo == null)
            {
                return View(sliderD);
            };

            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Type of file should be Image");
                return View(sliderD);
            }
            if (slider.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "Size of file should be less then 300");
                return View(sliderD);
            }

                if (sliderD == null) return NotFound();
                string path = Path.Combine(_env.WebRootPath, "img", sliderD.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                _db.Sliders.Remove(sliderD);
            
            

            string fileName = Guid.NewGuid().ToString() + slider.Photo.FileName;
            string paths = Path.Combine(_env.WebRootPath, "img", fileName);
            using (FileStream fileStream = new FileStream(paths, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(fileStream);
            }
            slider.Image = fileName;
            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
