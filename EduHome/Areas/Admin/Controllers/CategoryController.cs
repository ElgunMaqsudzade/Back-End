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
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            
            List<Category> categories = await _db.Categories.Take(10).ToListAsync();
            ViewBag.Count = _db.Tags.Count();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            bool isExist = _db.Categories.Any(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Category already exist");
                return View();
            }
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Categories.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            Category category = await _db.Categories.FirstOrDefaultAsync(e => e.Id == id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (!ModelState.IsValid) return View();
            Category category1 = await _db.Categories.Where(e => e.Id == id).FirstOrDefaultAsync();

            bool isExist = _db.Skills.Any(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Skill already exist");
                return View(category);
            }

            category1.Name = category.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Category category = _db.Categories.Where(e => e.Id == id).FirstOrDefault();
            return Json(category);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            Category category = await _db.Categories.Where(e => e.Id == id).FirstOrDefaultAsync();
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return Json(category);
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            ViewBag.Skip = skip;
            List<Category> categories = await _db.Categories.Skip(skip).Take(10).ToListAsync();

            return PartialView("_CategoryPartial", categories);
        }
    }
}
