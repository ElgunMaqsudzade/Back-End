using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _user;
        public EventController(AppDbContext db, UserManager<AppUser> user)
        {
            _db = db;
            _user = user;
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
                Comments = _db.Comments.Where(c => c.IsDeleted == false && c.EventSimpleId == id).Take(10).OrderByDescending(c => c.Id).Include(c => c.Children).Include(c => c.AppUser).ToList(),
            };
            if (eventVM.EventSimple == null) return NotFound();
            return View(eventVM);
        }
        public async Task<IActionResult> Comment(int dbid, string name, string email, string subject, string message)
        {

            string image = "User.png";
            Comment comment = new Comment()
            {
                Image = image,
                Email = email,
                Title = subject,
                Description = message,
                EventSimpleId = dbid,
                CreateTime = DateTime.UtcNow
            };
            if (!User.Identity.IsAuthenticated)
            {
                comment.Name = name + "(Guest)";
            }
            if (User.Identity.IsAuthenticated)
            {
                AppUser userManager = await _user.FindByNameAsync(User.Identity.Name);
                comment.Email = userManager.Email;
                comment.Name = userManager.UserName;
                comment.AppUserId = userManager.Id;
            }
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();

            Comment commentdb = _db.Comments.Where(t => t.IsDeleted == false && t.Id == comment.Id).Include(t => t.AppUser).Include(t => t.Children).ThenInclude(c => c.Children).FirstOrDefault();

            return PartialView("_CommentPartial", commentdb);
        }
        public async Task<IActionResult> Reply(int id)
        {
            Comment comment = await _db.Comments.Where(t => t.IsDeleted == false && t.Id == id).FirstOrDefaultAsync();
            return PartialView("_CommentInputPartial", comment);
        }
        public async Task<IActionResult> ReplyComment(string message, int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Comment parentcomment = await _db.Comments.Where(t => t.IsDeleted == false && t.Id == id).FirstOrDefaultAsync();
                AppUser userManager = await _user.FindByNameAsync(User.Identity.Name);
                Comment comment = new Comment()
                {
                    Name = userManager.UserName,
                    Email = userManager.Email,
                    Description = message,
                    ParentId = parentcomment.Id,
                    CreateTime = DateTime.UtcNow,
                    AppUserId = userManager.Id,
                };
                await _db.Comments.AddAsync(comment);
                await _db.SaveChangesAsync();
                return PartialView("_CommentReplyPartial", comment);
            }
            return Content("You must login before commenting something");
        }
        public async Task<IActionResult> Search(string word)
        {
            List<EventSimple> eventSimples = await _db.EventSimples.Where(b => b.IsDeleted == false && b.Title.Trim().ToLower().Contains(word.Trim().ToLower())).Take(10).ToListAsync();

            return PartialView("_SearchEventPartial", eventSimples);
        }
        
    }
}
