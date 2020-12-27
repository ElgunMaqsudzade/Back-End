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
    public class CourseViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public CourseViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string location)
        {
            if (location == "Home")
            {
                List<CourseSimple> courseSimples = await _db.CourseSimples.Where(t => t.IsDeleted == false && t.IsSimple == true).OrderByDescending(b => b.Id).ToListAsync();
                return View(await Task.FromResult(courseSimples));
            }
            else
            {
                List<CourseSimple> courseSimples = await _db.CourseSimples.Where(t => t.IsDeleted == false).OrderByDescending(b => b.Id).ToListAsync();
                return View(await Task.FromResult(courseSimples));
            }
        }
    }
}
