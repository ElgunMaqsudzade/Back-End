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
    public class TeacherViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public TeacherViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string location)
        {
            if (location == "About")
            {
                List<TeacherSimple> teachers = _db.TeacherSimples.Where(t => t.IsDeleted == false && t.IsSimple == true).Include(t => t.SocialMedias).Include(t => t.Profession).ToList();
                return View(await Task.FromResult(teachers));
            }
            else
            {
                List<TeacherSimple> teachers = _db.TeacherSimples.Where(t => t.IsDeleted == false).Include(t => t.SocialMedias).Include(t => t.Profession).ToList();
                return View(await Task.FromResult(teachers));
            }
        }
    }
}
