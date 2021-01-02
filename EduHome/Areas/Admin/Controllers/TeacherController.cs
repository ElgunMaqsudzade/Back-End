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
using static EduHome.Extensions.Extension;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public TeacherController(UserManager<AppUser> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<TeacherSimple> teacherSimples = await _db.TeacherSimples.Where(e => e.IsDeleted == false).Skip(0).Take(10).Include(t=>t.SocialMedias).Include(t=>t.Profession).ToListAsync();
            return View(teacherSimples);
        }
        public async Task<IActionResult> Detail(int id)
        {
            TeacherSimple teacherSimple = await _db.TeacherSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e=>e.TeacherDetail).FirstOrDefaultAsync();
            return View(teacherSimple);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            TeacherSimple teacherSimple = _db.TeacherSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            teacherSimple.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            
            return View();
        }

    }
}
