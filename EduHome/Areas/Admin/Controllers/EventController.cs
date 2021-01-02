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
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public EventController(UserManager<AppUser> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<EventSimple> eventSimples = await _db.EventSimples.Where(e => e.IsDeleted == false).Skip(0).Take(10).ToListAsync();
            return View(eventSimples);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.EventSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();

            EventSimple eventSimple = await _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.EventDetail).Include(e=>e.SpeakerEventSimples).ThenInclude(e=>e.Speaker).FirstOrDefaultAsync();
            return View(eventSimple);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        public IActionResult Delete(int id)
        {
            EventSimple eventSimple = _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            return Json(eventSimple);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            EventSimple eventSimple = _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            eventSimple.IsDeleted = true;
            await _db.SaveChangesAsync();
            return Json(eventSimple);
        }
        public async Task<IActionResult> Update(int id)
        {
            
            return View();
        }

    }
}
