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
    public class SearchController : Controller
    {
        private readonly AppDbContext _db;
        public SearchController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string keyword,string location)
        {
            ViewBag.Card = location;
            ViewBag.Keyword = keyword;
            return View();
        }
        public async Task<IActionResult> Searchall(string search)
        {
            if (search == null) return NotFound();
            SearchVM searchVM = new SearchVM()
            {
                BlogSimples = await _db.BlogSimples.Where(b => b.IsDeleted == false && b.Title.Trim().ToLower().Contains(search)).ToListAsync(),
                EventSimples = await _db.EventSimples.Where(b => b.IsDeleted == false && b.Title.Trim().ToLower().Contains(search)).ToListAsync(),
                CourseSimples = await _db.CourseSimples.Where(b => b.IsDeleted == false && b.Title.Trim().ToLower().Contains(search)).ToListAsync(),
                TeacherSimples = await _db.TeacherSimples.Where(b => b.IsDeleted == false && b.Fullname.Trim().ToLower().Contains(search)).ToListAsync()
            };
            return View(searchVM);
        }

    }
}
