using System;
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
        public IActionResult Index(string name, int? page = 1, int take = 6)
        {
            //it is for determining is it from sidebar filter at Detail or not
            if (name != null)
            {
                ViewBag.CategoryName = name;
                ViewBag.IsTrue = true;
            }
            else
            {
                ViewBag.IsTrue = false;
            }
            if (page == null || page == 0) return View(1);
            if ((page - 1) * take > _db.EventSimples.Count()) return NotFound();
            return View(page);
        }
        [HttpPost]
        public IActionResult Index(string search)
        {
            return RedirectToAction("Index", "Search", new { keyword = search, location = "Event" });
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
        public async Task<IActionResult> Comment(int dbid, string name, string email, string subject, string message)
        {
            Comment comment = new Comment()
            {
                Name = "Guest - " + name,
                Email = email,
                Title = subject,
                Description = message,
                EventSimpleId = dbid,
                CreateTime = DateTime.UtcNow
            };
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();

            return PartialView("_CommentPartial", comment);
        }
        public async Task<IActionResult> Search(string word)
        {
            List<EventSimple> eventSimples = await _db.EventSimples.Where(b => b.IsDeleted == false && b.Title.Trim().ToLower().Contains(word.Trim().ToLower())).Take(10).ToListAsync();

            return PartialView("_SearchEventPartial", eventSimples);
        }
    }
}
