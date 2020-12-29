﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        public EventController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            TempData["DetailId"] = id;
            EventVM eventVM = new EventVM()
            {
                EventSimple = _db.EventSimples.Where(b => b.IsDeleted == false && b.Id == id).Include(b => b.EventDetail).FirstOrDefault(),
                Comments = _db.Comments.Where(c => c.IsDeleted == false && c.EventSimpleId == id).Take(10).OrderByDescending(c => c.Id).ToList(),
            };
            if (eventVM.EventSimple == null) return NotFound();
            return View(eventVM);
        }
        public async Task<IActionResult> Comment(string name, string email, string subject, string message)
        {
            Comment comment = new Comment()
            {
                Name = name,
                Email = email,
                Title = subject,
                Description = message,
                EventSimpleId = (int)TempData["DetailId"],
                CreateTime = DateTime.UtcNow
            };
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();

            return PartialView("_CommentPartial", comment);
        }
    }
}
