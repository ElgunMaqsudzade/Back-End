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
    public class TagController : Controller
    {
        private readonly AppDbContext _db;
        public TagController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Tag> tags = await _db.Tags.Take(10).ToListAsync();
            ViewBag.Count = _db.Tags.Count();
            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {

            await _db.Tags.AddAsync(tag);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Tag tag = _db.Tags.Where(e => e.Id == id).FirstOrDefault();
            return Json(tag);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Tags.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            Tag tag = await _db.Tags.FirstOrDefaultAsync(e => e.Id == id);
            return View(tag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Tag tag)
        {
            if (!ModelState.IsValid) return View();
            Tag tag1 = await _db.Tags.Where(e => e.Id == id).FirstOrDefaultAsync();

            bool isExist = _db.Skills.Any(c => c.Name.Trim().ToLower() == tag.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Skill already exist");
                return View(tag1);
            }

            tag1.Name = tag.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            Tag tag = await _db.Tags.Where(e => e.Id == id).FirstOrDefaultAsync();
            _db.Tags.Remove(tag);
            await _db.SaveChangesAsync();
            return Json(tag);
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            ViewBag.Skip = skip;
            List<Tag> tags = await _db.Tags.Skip(skip).Take(10).ToListAsync();

            return PartialView("_TagPartial", tags);
        }
    }
}
