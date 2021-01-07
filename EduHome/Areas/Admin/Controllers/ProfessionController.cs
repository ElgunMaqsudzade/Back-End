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
    public class ProfessionController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProfessionController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Profession> professions = await _db.Professions.Take(10).ToListAsync();
            ViewBag.Count = _db.Professions.Count();
            return View(professions);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profession profession)
        {

            await _db.Professions.AddAsync(profession);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Professions.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            Profession profession = await _db.Professions.FirstOrDefaultAsync(e => e.Id == id);
            return View(profession);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Profession profession)
        {
            if (!ModelState.IsValid) return View();
            Profession profession1 = await _db.Professions.Where(e => e.Id == id).FirstOrDefaultAsync();

            bool isExist = _db.Professions.Any(c => c.Name.Trim().ToLower() == profession.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Skill already exist");
                return View(profession1);
            }

            profession1.Name = profession.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Profession profession = _db.Professions.Where(e => e.Id == id).FirstOrDefault();
            return Json(profession);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            Profession profession = await _db.Professions.Where(e => e.Id == id).FirstOrDefaultAsync();
            _db.Professions.Remove(profession);
            await _db.SaveChangesAsync();
            return Json(profession);
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            ViewBag.Skip = skip;
            List<Profession> professions = await _db.Professions.Skip(skip).Take(10).ToListAsync();

            return PartialView("_ProfessionPartial", professions);
        }
    }
}
