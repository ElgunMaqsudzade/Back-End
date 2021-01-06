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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public TeacherController(UserManager<AppUser> userManager, AppDbContext db, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<TeacherSimple> teacherSimples = await _db.TeacherSimples.Where(e => e.IsDeleted == false)
                .Skip(0).Take(10).Include(t => t.SocialMedias).Include(t => t.Profession).ToListAsync();
            ViewBag.Count = _db.TeacherSimples.Count();
            return View(teacherSimples);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.TeacherSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();

            TeacherSimple teacherSimple = await _db.TeacherSimples.Where(e => e.IsDeleted == false && e.Id == id)
                .Include(e => e.TeacherDetail).Include(t => t.TeacherSkills).ThenInclude(t => t.Skill).Include(t => t.SocialMedias).Include(t => t.Profession).FirstOrDefaultAsync();
            return View(teacherSimple);
        }
        public async Task<IActionResult> Create()
        {
            TeacherForCreateVM teacherForCreateVM = new TeacherForCreateVM()
            {
                Skills = await _db.Skills.ToListAsync(),
                TeacherSkills = await _db.TeacherSkills.ToListAsync(),
                Professions = await _db.Professions.ToListAsync(),
                Profession = await _db.Professions.FirstOrDefaultAsync()
            };
            return View(teacherForCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherForCreateVM teacher, int design, int language, int teamleader, int development, int innovation, int communication, int Profession)
        {
            
            if (!ModelState.IsValid) return View();
            TeacherForCreateVM teacherForCreateVM = new TeacherForCreateVM()
            {
                Skills = await _db.Skills.ToListAsync(),
                TeacherSkills = await _db.TeacherSkills.ToListAsync(),
                Professions = await _db.Professions.ToListAsync(),
                Profession = await _db.Professions.FirstOrDefaultAsync()
            };
            bool isExist = _db.TeacherSimples.Where(c => c.IsDeleted == false).Any(c => c.Fullname.Trim().ToLower() == teacher.TeacherSimple.Fullname.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Teacher already exist");
                return View(teacherForCreateVM);
            }
            if (teacher.TeacherSimple.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View(teacherForCreateVM);
            }
            if (!teacher.TeacherSimple.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View(teacherForCreateVM);
            }
            if (!teacher.TeacherSimple.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View(teacherForCreateVM);
            }

            string folder = Path.Combine("img", "teacher");
            string fileName = await teacher.TeacherSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            teacher.TeacherSimple.Image = fileName;
            teacher.TeacherSimple.ProfessionId = Profession;



            teacher.TeacherSimple.CreateTime = DateTime.UtcNow;
            await _db.TeacherSimples.AddAsync(teacher.TeacherSimple);
            await _db.SaveChangesAsync();

            teacher.TeacherDetail.TeacherSimpleId = teacher.TeacherSimple.Id;
            await _db.TeacherDetails.AddAsync(teacher.TeacherDetail);
            await _db.SaveChangesAsync();

            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacher.TeacherSimple.Id, SkillId = 1, SkillValue = language });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacher.TeacherSimple.Id, SkillId = 2, SkillValue = teamleader });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacher.TeacherSimple.Id, SkillId = 3, SkillValue = development });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacher.TeacherSimple.Id, SkillId = 4, SkillValue = design });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacher.TeacherSimple.Id, SkillId = 6, SkillValue = innovation });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacher.TeacherSimple.Id, SkillId = 7, SkillValue = communication });
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            TeacherSimple teacherSimple = _db.TeacherSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            return Json(teacherSimple);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            TeacherSimple teacherSimple = _db.TeacherSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            teacherSimple.IsDeleted = true;
            teacherSimple.DeleteTime = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return Json(teacherSimple);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.TeacherSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();
            TeacherForCreateVM teacherForCreateVM = new TeacherForCreateVM()
            {
                TeacherSimple = await _db.TeacherSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.TeacherDetail).Include(t=>t.TeacherSkills).FirstOrDefaultAsync(),
                TeacherDetail = await _db.TeacherDetails.Where(e => e.TeacherSimpleId == id).FirstOrDefaultAsync(),
                Skills = await _db.Skills.ToListAsync(),
                TeacherSkills = await _db.TeacherSkills.Where(e => e.TeacherSimpleId == id).ToListAsync(),
                Professions = await _db.Professions.ToListAsync(),
                Profession = await _db.Professions.FirstOrDefaultAsync(),
            };
            return View(teacherForCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TeacherForCreateVM teacher, int design, int language, int teamleader, int development, int innovation, int communication, int Profession)
        {
            if (!ModelState.IsValid) return View();
            TeacherForCreateVM teacherForCreateVM = new TeacherForCreateVM()
            {
                TeacherSimple = await _db.TeacherSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.TeacherDetail).Include(t => t.TeacherSkills).FirstOrDefaultAsync(),
                TeacherDetail = await _db.TeacherDetails.Where(e => e.TeacherSimpleId == id).FirstOrDefaultAsync(),
                TeacherSkills = await _db.TeacherSkills.Where(e => e.TeacherSimpleId == id).Include(e=>e.Skill).ToListAsync(),
                Skills = await _db.Skills.ToListAsync(),
                Professions = await _db.Professions.ToListAsync(),
                Profession = await _db.Professions.FirstOrDefaultAsync(),
            };

            TeacherSimple teacherSimple = await _db.TeacherSimples.Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefaultAsync();
            TeacherDetail teacherDetail = await _db.TeacherDetails.Where(c => c.TeacherSimpleId == id).FirstOrDefaultAsync();
            bool isExist = _db.TeacherSimples.Where(c => c.IsDeleted == false).Any(c => c.Fullname.Trim().ToLower() == teacher.TeacherSimple.Fullname.Trim().ToLower() && c.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("", "This Teacher already exist");
                return View(teacherForCreateVM);
            }
            if (teacher.TeacherSimple.Photo != null)
            {
                if (!teacher.TeacherSimple.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please,add Image file");
                    return View(teacherForCreateVM);
                }
                if (!teacher.TeacherSimple.Photo.MaxSize(500))
                {
                    ModelState.AddModelError("", "Max size of Image should be lower than 500");
                    return View(teacherForCreateVM);
                }
                string folder = Path.Combine("img", "teacher");
                string fileName = await teacher.TeacherSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                string path = Path.Combine(_env.WebRootPath, folder, teacherSimple.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                teacherSimple.Image = fileName;
            }


            teacherSimple.ProfessionId = Profession;
            teacherSimple.Fullname = teacher.TeacherSimple.Fullname;
            teacherSimple.IsSimple = teacher.TeacherSimple.IsSimple;
            teacherSimple.UpdateTime = DateTime.UtcNow;
            teacherDetail.Mail = teacher.TeacherDetail.Mail;
            teacherDetail.Skype = teacher.TeacherDetail.Skype;
            teacherDetail.Phone = teacher.TeacherDetail.Phone;
            teacherDetail.Hobbies = teacher.TeacherDetail.Hobbies;
            teacherDetail.Degree = teacher.TeacherDetail.Degree;
            teacherDetail.Faculty = teacher.TeacherDetail.Faculty;
            teacherDetail.Experience = teacher.TeacherDetail.Experience;
            teacherDetail.AboutContent = teacher.TeacherDetail.AboutContent;

            await _db.SaveChangesAsync();

            foreach (var s in teacherForCreateVM.TeacherSkills)
            {
                _db.TeacherSkills.Remove(s);
            }
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacherSimple.Id, SkillId = 1, SkillValue = language });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacherSimple.Id, SkillId = 2, SkillValue = teamleader });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacherSimple.Id, SkillId = 3, SkillValue = development });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacherSimple.Id, SkillId = 4, SkillValue = design });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacherSimple.Id, SkillId = 6, SkillValue = innovation });
            await _db.TeacherSkills.AddAsync(new TeacherSkill { TeacherSimpleId = teacherSimple.Id, SkillId = 7, SkillValue = communication });
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            ViewBag.Skip = skip;
            List<TeacherSimple> teacherSimples = await _db.TeacherSimples.Where(t => t.IsDeleted == false).Skip(skip).Take(10).Include(t => t.SocialMedias).Include(t => t.Profession).ToListAsync();

            return PartialView("_TeacherPartial", teacherSimples);
        }
    }
}
