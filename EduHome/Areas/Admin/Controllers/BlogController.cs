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
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public BlogController(UserManager<AppUser> userManager, AppDbContext db, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<BlogSimple> blogSimples = await _db.BlogSimples.Where(e => e.IsDeleted == false).Skip(0).Take(10).ToListAsync();
            return View(blogSimples);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.BlogSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();

            BlogSimple blogSimple = await _db.BlogSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.BlogDetail).FirstOrDefaultAsync();
            return View(blogSimple);
        }
        public async Task<IActionResult> Create()
        {
            BlogForCreateVM blogForCreateVM = new BlogForCreateVM()
            {
                Categories = await _db.Categories.ToListAsync(),
                Category = await _db.Categories.FirstOrDefaultAsync(),
                Tags = await _db.Tags.ToListAsync(),
                TagBlogSimples = await _db.TagBlogSimples.ToListAsync(),
            };

            return View(blogForCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogForCreateVM blog, List<int> Tags, int Category)
        {


            //if (!ModelState.IsValid) return View();
            BlogForCreateVM blogForCreateVM = new BlogForCreateVM()
            {
                Categories = await _db.Categories.ToListAsync(),
                Category = await _db.Categories.FirstOrDefaultAsync(),
                Tags = await _db.Tags.ToListAsync(),
                TagBlogSimples = await _db.TagBlogSimples.ToListAsync(),
            };

            bool isExist = _db.BlogSimples.Where(c => c.IsDeleted == false).Any(c => c.Title.Trim().ToLower() == blog.BlogSimple.Title.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Blog already exist");
                return View(blogForCreateVM);
            }
            if (blog.BlogSimple.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View(blogForCreateVM);
            }
            if (!blog.BlogSimple.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View(blogForCreateVM);
            }
            if (!blog.BlogSimple.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View(blogForCreateVM);
            }

            string folder = Path.Combine("img", "blog");
            string fileName = await blog.BlogSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            blog.BlogSimple.Image = fileName;
            blog.BlogSimple.CategoryId = Category;

            blog.BlogSimple.CreateTime = DateTime.UtcNow;
            await _db.BlogSimples.AddAsync(blog.BlogSimple);
            await _db.SaveChangesAsync();

            foreach (int id in Tags)
            {
                await _db.TagBlogSimples.AddAsync(new TagBlogSimple { BlogSimpleId = blog.BlogSimple.Id, TagId = id });
            }

            blog.BlogDetail.BlogSimpleId = blog.BlogSimple.Id;
            await _db.BlogDetails.AddAsync(blog.BlogDetail);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.BlogSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();
            BlogForCreateVM blogForCreateVM = new BlogForCreateVM()
            {
                BlogSimple = await _db.BlogSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.BlogDetail).FirstOrDefaultAsync(),
                BlogDetail = await _db.BlogDetails.Where(e => e.BlogSimpleId == id).FirstOrDefaultAsync(),
                Categories = await _db.Categories.ToListAsync(),
                Tags = await _db.Tags.ToListAsync(),
                TagBlogSimples = await _db.TagBlogSimples.Where(c => c.BlogSimple.Id == id).ToListAsync(),
            };
            return View(blogForCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BlogForCreateVM blog, List<int> Tags, int Category)
        {
            //We have int BlogSimpleId at BlogDetail for one for one relation we should either 
            //do that nullable or just do not use (!ModelState.Isvalid)
            BlogForCreateVM blogForCreateVM = new BlogForCreateVM()
            {
                BlogSimple = await _db.BlogSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.BlogDetail).FirstOrDefaultAsync(),
                BlogDetail = await _db.BlogDetails.Where(e => e.BlogSimpleId == id).FirstOrDefaultAsync(),
                Categories = await _db.Categories.ToListAsync(),
                Tags = await _db.Tags.ToListAsync(),
                TagBlogSimples = await _db.TagBlogSimples.Where(c => c.BlogSimple.Id == id).ToListAsync(),
            };

            BlogSimple blogSimple = await _db.BlogSimples.Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefaultAsync();
            BlogDetail blogDetail = await _db.BlogDetails.Where(c => c.BlogSimpleId == id).FirstOrDefaultAsync();

            bool isExist = _db.BlogSimples.Where(c => c.IsDeleted == false).Any(c => c.Title.Trim().ToLower() == blog.BlogSimple.Title.Trim().ToLower() && c.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("", "This Blog already exist");
                return View(blogForCreateVM);
            }
            if (blog.BlogSimple.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View(blogForCreateVM);
            }
            if (!blog.BlogSimple.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View(blogForCreateVM);
            }
            if (!blog.BlogSimple.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View(blogForCreateVM);
            }

            string folder = Path.Combine("img", "blog");
            string fileName = await blog.BlogSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            string path = Path.Combine(_env.WebRootPath, folder, blogSimple.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            blogSimple.CategoryId = Category;
            blogSimple.Image = fileName;
            blogSimple.Title = blog.BlogSimple.Title;
            blogSimple.Author = blog.BlogSimple.Author;
            blogSimple.UpdateTime = DateTime.UtcNow;
            blogDetail.AboutContent = blog.BlogDetail.AboutContent;

            await _db.SaveChangesAsync();

            foreach (var s in blogForCreateVM.TagBlogSimples)
            {
                _db.TagBlogSimples.Remove(s);
            }
            foreach (var i in Tags)
            {
                _db.TagBlogSimples.Add(new TagBlogSimple { BlogSimpleId = blogSimple.Id, TagId = i });
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            BlogSimple blogSimple = _db.BlogSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            return Json(blogSimple);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            BlogSimple blogSimple = _db.BlogSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            blogSimple.IsDeleted = true;
            await _db.SaveChangesAsync();
            return Json(blogSimple);
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            ViewBag.Skip = skip;
            List<BlogSimple> blogSimples = await _db.BlogSimples.Where(t => t.IsDeleted == false).Skip(skip).Take(10).ToListAsync();

            return PartialView("_BlogPartial", blogSimples);
        }
    }
}
