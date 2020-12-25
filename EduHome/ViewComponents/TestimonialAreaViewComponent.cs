using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;

namespace EduHome.ViewComponents
{
    public class TestimonialAreaViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public TestimonialAreaViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<TestimonialArea> testimonialAreas = await _db.TestimonialAreas.Where(t => t.IsDeleted == false).Include(s => s.Student).ToListAsync();
            return View(await Task.FromResult(testimonialAreas));
        }
    }
}
