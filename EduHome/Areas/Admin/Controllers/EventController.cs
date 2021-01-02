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
        public async Task<IActionResult> Detail(int id)
        {
            EventSimple eventSimple = await _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e=>e.EventDetail).FirstOrDefaultAsync();
            return View(eventSimple);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            EventSimple eventSimple = _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefault();
            eventSimple.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            
            return View();
        }

    }
}
