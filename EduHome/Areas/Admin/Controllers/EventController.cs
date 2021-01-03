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
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public EventController(UserManager<AppUser> userManager, AppDbContext db, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<EventSimple> eventSimples = await _db.EventSimples.Where(e => e.IsDeleted == false).Skip(0).Take(20).ToListAsync();
            return View(eventSimples);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.EventSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();
            EventSimple eventSimple = await _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.EventDetail).FirstOrDefaultAsync();
            return View(eventSimple);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Speakers = await _db.Speakers.Where(d => d.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventForCreateVM eventvm, List<int> Speakers,List<int> Tags, int Category)
        {
            ViewBag.Speakers = await _db.Speakers.Where(d => d.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            if (Speakers.Count() == 0)
            {
                ModelState.AddModelError("Speakers", "You need to choose at least one Speaker");
                return View();
            }
            //if (!ModelState.IsValid) return View();

            bool isExist = _db.EventSimples.Where(c => c.IsDeleted == false).Any(c => c.Title.Trim().ToLower() == eventvm.EventSimple.Title.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("", "This Event already exist");
                return View();
            }
            if (eventvm.EventSimple.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View();
            }
            if (!eventvm.EventSimple.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View();
            }
            if (!eventvm.EventSimple.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View();
            }

            string folder = Path.Combine("img", "event");
            string fileName = await eventvm.EventSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            eventvm.EventSimple.Image = fileName;
            eventvm.EventSimple.CategoryId = Category;
            eventvm.EventSimple.CreateTime = DateTime.UtcNow;
            await _db.EventSimples.AddAsync(eventvm.EventSimple);
            await _db.SaveChangesAsync();

            foreach (int id in Speakers)
            {
                await _db.SpeakerEventSimples.AddAsync(new SpeakerEventSimple { EventSimpleId = eventvm.EventSimple.Id, SpeakerId = id });
            }
            foreach (int id in Tags)
            {
                await _db.TagEventSimples.AddAsync(new TagEventSimple { EventSimpleId = eventvm.EventSimple.Id, TagId = id });
            }
            
            eventvm.EventDetail.EventSimpleId = eventvm.EventSimple.Id;
            await _db.EventDetails.AddAsync(eventvm.EventDetail);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
            eventSimple.DeleteTime = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return Json(eventSimple);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.EventSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();
            EventForCreateVM courseForCreateVM = new EventForCreateVM()
            {
                EventSimple = await _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.EventDetail).FirstOrDefaultAsync(),
                EventDetail = await _db.EventDetails.Where(e => e.EventSimpleId == id).FirstOrDefaultAsync(),
                Categories = await _db.Categories.ToListAsync(),
                Tags = await _db.Tags.ToListAsync(),
                Speakers = await _db.Speakers.ToListAsync(), 
            };
            return View(courseForCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, EventForCreateVM eventvm, List<int> Speakers, List<int> Tags, int Category)
        {
            EventForCreateVM courseForCreateVM = new EventForCreateVM()
            {
                EventSimple = await _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.EventDetail).FirstOrDefaultAsync(),
                EventDetail = await _db.EventDetails.Where(e => e.EventSimpleId == id).FirstOrDefaultAsync(),
                Categories = await _db.Categories.ToListAsync(),
                Tags = await _db.Tags.ToListAsync(),
                Speakers = await _db.Speakers.ToListAsync(),
            };
            if (Speakers.Count() == 0)
            {
                ModelState.AddModelError("Speakers", "You need to choose at least one Speaker");
                return View(courseForCreateVM);
            }
            //if (!ModelState.IsValid) return View();

            bool isExist = _db.EventSimples.Where(c => c.IsDeleted == false).Any(c => c.Title.Trim().ToLower() == eventvm.EventSimple.Title.Trim().ToLower() && c.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("", "This Event already exist");
                return View(courseForCreateVM);
            }
            if (eventvm.EventSimple.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View(courseForCreateVM);
            }
            if (!eventvm.EventSimple.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View(courseForCreateVM);
            }
            if (!eventvm.EventSimple.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View(courseForCreateVM);
            }

            string folder = Path.Combine("img", "event");
            string fileName = await eventvm.EventSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);

            EventSimple eventSimple1 = await _db.EventSimples.Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefaultAsync();
            EventDetail eventDetail = await _db.EventDetails.Where(c => c.EventSimpleId == id).FirstOrDefaultAsync();

            eventSimple1.Image = fileName;
            eventSimple1.Title = eventvm.EventSimple.Title;
            eventSimple1.Location = eventvm.EventSimple.Location;
            eventSimple1.StartingTime = eventvm.EventSimple.StartingTime;
            eventSimple1.UpdateTime = eventvm.EventSimple.UpdateTime;
            eventDetail.AboutContent = eventvm.EventDetail.AboutContent;
            eventSimple1.CategoryId = Category;

            await _db.SaveChangesAsync();


            foreach (var i in Tags)
            {
                _db.TagEventSimples.Add(new TagEventSimple { EventSimpleId = eventSimple1.Id, TagId = i });
            }
            foreach (var s in Speakers)
            {
                _db.SpeakerEventSimples.Add(new SpeakerEventSimple { EventSimpleId = eventSimple1.Id, SpeakerId = s });
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));




        }

    }
}
