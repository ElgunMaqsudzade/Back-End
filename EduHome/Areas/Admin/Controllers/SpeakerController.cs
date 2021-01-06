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
    public class SpeakerController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SpeakerController( AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Speaker> speakers = await _db.Speakers.Where(e => e.IsDeleted == false).Include(e=>e.Profession).Skip(0).Take(10).ToListAsync();
            ViewBag.Count = _db.Speakers.Count();
            return View(speakers);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Speakers.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();

            Speaker speaker = await _db.Speakers.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.Profession).FirstOrDefaultAsync();
            return View(speaker);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Profession = await _db.Professions.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Speaker speaker,int Profession)
        {


            if (!ModelState.IsValid) return View();

            if (speaker.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View();
            }
            if (!speaker.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View();
            }
            if (!speaker.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View();
            }

            string folder = Path.Combine("img", "event");
            string fileName = await speaker.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            speaker.Image = fileName;

            speaker.ProfessionId = Profession;
            speaker.CreateTime = DateTime.UtcNow;
            await _db.Speakers.AddAsync(speaker);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Speakers.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();
            Speaker speaker =await _db.Speakers.Include(c=>c.Profession).FirstOrDefaultAsync(s => s.Id == id);
            ViewBag.Profession = await _db.Professions.ToListAsync();
            return View(speaker);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Speaker speaker,int Profession)
        {
            List<Speaker> speakers = await _db.Speakers.Where(c => c.IsDeleted == false).ToListAsync();

            Speaker speaker1 = await _db.Speakers.Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefaultAsync();

            if (!ModelState.IsValid) return View(speakers);

            if (speaker1.Photo != null)
            {
                if (!speaker1.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please,add Image file");
                    return View(speakers);
                }
                if (!speaker1.Photo.MaxSize(500))
                {
                    ModelState.AddModelError("", "Max size of Image should be lower than 500");
                    return View(speakers);
                }
                string folder = Path.Combine("img", "speaker");
                string fileName = await speaker.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                string path = Path.Combine(_env.WebRootPath, folder, speaker1.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                speaker1.Image = fileName;
            }

            speaker1.ProfessionId = Profession;
            speaker1.Name = speaker.Name;
            speaker1.UpdateTime = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Speaker speaker = _db.Speakers.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            return Json(speaker);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            Speaker speaker = _db.Speakers.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            speaker.IsDeleted = true;
            await _db.SaveChangesAsync();
            return Json(speaker);
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            ViewBag.Skip = skip;
            List<Speaker> speakers = await _db.Speakers.Where(t => t.IsDeleted == false).Skip(skip).Take(10).ToListAsync();

            return PartialView("_SpeakerPartial", speakers);
        }
    }
}
