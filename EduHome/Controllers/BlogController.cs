using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _user;
        public BlogController(AppDbContext db, UserManager<AppUser> user)
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
                ViewBag.hasFilter = true;
            }
            else
            {
                ViewBag.hasFilter = false;
            }
            if (page == null || page == 0) return View(1);
            if ((page - 1) * take > _db.BlogSimples.Count()) return NotFound();
            return View(page);
        }
        [HttpPost]
        public IActionResult Index(string search)
        {
            return RedirectToAction("Index", "Search", new { keyword = search, location = "Blog" });
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
            string image = "User.png";
            if (User.Identity.IsAuthenticated)
            {
                AppUser userManager =await _user.FindByNameAsync(User.Identity.Name);
                email = userManager.Email;
                name = userManager.UserName;
                image = userManager.Image;
            }
            Comment comment = new Comment()
            {
                Image = image,
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
        public async Task<IActionResult> Search(string word)
        {
            List<BlogSimple> blogSimples = await _db.BlogSimples.Where(b => b.IsDeleted == false && b.Title.Trim().ToLower().Contains(word.Trim().ToLower())).Take(10).ToListAsync();

            return PartialView("_SearchBlogPartial", blogSimples);
        }

    }
}
