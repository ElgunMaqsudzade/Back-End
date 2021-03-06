﻿using System;
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
    public class SkillController : Controller
    {
        private readonly AppDbContext _db;
        public SkillController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Skill> skills = await _db.Skills.Take(10).ToListAsync();
            ViewBag.Count = _db.Skills.Count();
            return View(skills);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Skill skill)
        {
            bool isExist = _db.Skills.Any(c => c.Name.Trim().ToLower() == skill.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Skill already exist");
                return View();
            }
            await _db.Skills.AddAsync(skill);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Skills.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            Skill skill = await _db.Skills.FirstOrDefaultAsync(e => e.Id == id);
            return View(skill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Skill skill)
        {
            if (!ModelState.IsValid) return View();
            Skill skill1 = await _db.Skills.Where(e => e.Id == id).FirstOrDefaultAsync();

            bool isExist = _db.Skills.Any(c => c.Name.Trim().ToLower() == skill.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Skill already exist");
                return View(skill1);
            }

            skill1.Name = skill.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Skill skill = _db.Skills.Where(e => e.Id == id).FirstOrDefault();
            return Json(skill);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            Skill skill = await _db.Skills.Where(e => e.Id == id).FirstOrDefaultAsync();
            _db.Skills.Remove(skill);
            await _db.SaveChangesAsync();
            return Json(skill);
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            ViewBag.Skip = skip;
            List<Skill> skills = await _db.Skills.Skip(skip).Take(10).ToListAsync();

            return PartialView("_SkillPartial", skills);
        }
    }
}
