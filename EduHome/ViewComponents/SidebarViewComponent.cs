using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;
using EduHome.ViewModels;

namespace EduHome.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public SidebarViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string location)
        {
            ViewBag.Location = location;
            SidebarVM sidebarVM = new SidebarVM()
            {
                BlogSimples = _db.BlogSimples.Where(b => b.IsDeleted == false).Include(b => b.TagBlogSimples).ThenInclude(b => b.Tag).ToList(),
                CourseSimples = _db.CourseSimples.Where(b => b.IsDeleted == false).Include(b => b.TagCourseSimples).ThenInclude(b => b.Tag).ToList(),
                EventSimples = _db.EventSimples.Where(b => b.IsDeleted == false).Include(b => b.TagEventSimples).ThenInclude(b => b.Tag).ToList(),
                Categories = _db.Categories.Include(b=>b.BlogSimples).Include(b=>b.CourseSimples).Include(b=>b.EventSimples).ToList()
            };
            return View(sidebarVM);
        }
    }
}
