using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        public BlogController(UserManager<AppUser> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
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
        public IActionResult Create()
        {
            
            return View();
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
        public async Task<IActionResult> Update(int id)
        {
            
            return View();
        }

    }
}
