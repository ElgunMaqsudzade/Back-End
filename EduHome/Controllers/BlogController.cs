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
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string name , int? page = 1, int take = 6)
        {
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
            if ((page - 1) * take > _db.BlogSimples.Count()) return NotFound();
            return View(page);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            TempData["DetailId"] = id;
            BlogVM blogVM = new BlogVM()
            {
                BlogSimple = _db.BlogSimples.Where(b => b.IsDeleted == false && b.Id == id).Include(b => b.BlogDetail).FirstOrDefault(),
                Comments = _db.Comments.Where(c => c.IsDeleted == false && c.BlogSimpleId == id).Take(10).OrderByDescending(c => c.Id).ToList(),
            };
            if (blogVM.BlogSimple == null) return NotFound();
            return View(blogVM);
        }
        public async Task<IActionResult> Comment(int dbid, string name, string email, string subject, string message)
        {
            Comment comment = new Comment()
            {
                Name = name,
                Email = email,
                Title = subject,
                Description = message,
                BlogSimpleId = dbid,
                CreateTime = DateTime.UtcNow
            };
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();

            return PartialView("_CommentPartial", comment);
        }
    }
}
