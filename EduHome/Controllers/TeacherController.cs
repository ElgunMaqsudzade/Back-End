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
        public IActionResult Index()
        {
            return View();
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
