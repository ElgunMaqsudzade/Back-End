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
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db)
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
            CourseVM courseVM = new CourseVM()
            {
                CourseSimple = _db.CourseSimples.Where(b => b.IsDeleted == false && b.Id == id).Include(b => b.CourseDetail).ThenInclude(d=>d.CourseFeature).FirstOrDefault(),
                Comments = _db.Comments.Where(c => c.IsDeleted == false && c.CourseSimpleId == id).Take(10).OrderByDescending(c => c.Id).ToList(),
            };
            if (courseVM.CourseSimple == null) return NotFound();
            return View(courseVM);
        }
        public async Task<IActionResult> Comment(string name, string email, string subject, string message)
        {
            if (name == null || email == null || subject == null || message == null) return NotFound();
            Comment comment = new Comment()
            {
                Name = name,
                Email = email,
                Title = subject,
                Description = message,
                CourseSimpleId = (int)TempData["DetailId"],
                CreateTime = DateTime.UtcNow
            };
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();

            return PartialView("_CommentPartial", comment);
        }
        public IActionResult Category(string name)
        {
            TempData["CategoryName"] = name;
            return RedirectToAction("Index");
        }
    }
}
