using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        public TeacherController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? page = 1, int take = 6)
        {
            ViewBag.isTrue = true;
            if (page == null || page == 0) return View(1);
            if ((page - 1) * take > _db.TeacherSimples.Count()) return NotFound();
            return View(page);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            TeacherSimple teacherSimple = _db.TeacherSimples.Where(b => b.IsDeleted == false && b.Id == id)
                .Include(b => b.TeacherDetail).ThenInclude(t=>t.TeacherSkills).ThenInclude(t=>t.Skill)
                .Include(t=>t.Profession).Include(t=>t.SocialMedias).FirstOrDefault();
            
            if (teacherSimple == null) return NotFound();
            return View(teacherSimple);
        }
    }
}
