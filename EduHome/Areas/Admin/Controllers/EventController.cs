using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            List<EventSimple> eventSimples = await _db.EventSimples.Where(e => e.IsDeleted == false).Skip(0).Take(10).ToListAsync();
            ViewBag.Count = _db.EventSimples.Count();
            return View(eventSimples);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.EventSimples.Where(c => c.IsDeleted == false).Any(c => c.Id == id);
            if (!isExist) return NotFound();
            EventSimple eventSimple = await _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id)
                .Include(e => e.EventDetail).Include(i => i.Category).Include(t => t.TagEventSimples).ThenInclude(t => t.Tag).FirstOrDefaultAsync();
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
        public async Task<IActionResult> Create(EventForCreateVM eventvm, List<int> Speakers, List<int> Tags, int Category)
        {
            ViewBag.Speakers = await _db.Speakers.Where(d => d.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            if (Speakers.Count() == 0)
            {
                ModelState.AddModelError("Speakers", "You need to choose at least one Speaker");
                return View();
            }
            if (!ModelState.IsValid) return View();

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


            List<Subscriber> subscribers = _db.Subscribers.ToList();
            foreach (Subscriber s in subscribers)
            {
                await _db.SubscriberEventSimples.AddAsync(new SubscriberEventSimple { EventSimpleId = eventvm.EventSimple.Id, SubscriberId = s.Id });
            }


            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("imbackend4000@gmail.com", "backend318");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            foreach (Subscriber s in subscribers)
            {
                MailMessage message = new MailMessage("imbackend4000@gmail.com", s.Mail);
                message.Subject = "EduHome Event Review";


                message.Body = "<div style='padding:20px;' class='container'><div class='row justify-content-center'><div class='col-6 text-center'>" +
                    "<h4>Hello, Our dear Subscriber:)</h4><h4 style='color: red'>Want to learn more in 2021?</h4>" +
                    "<h4>Create a goal and Eduhome will help you stay on track.</h4>" +
                    "<h5> We are making new event at our Course.Check out the Details :)</h5></div></div></div>";
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                client.Send(message);
            }

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
            EventForCreateVM eventForCreateVM = new EventForCreateVM()
            {
                EventSimple = await _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.EventDetail).Include(e => e.Category).FirstOrDefaultAsync(),
                EventDetail = await _db.EventDetails.Where(e => e.EventSimpleId == id).FirstOrDefaultAsync(),
                TagEventSimples = await _db.TagEventSimples.Where(e => e.EventSimple.Id == id).ToListAsync(),
                SpeakerEventSimples = await _db.SpeakerEventSimples.Where(e => e.EventSimpleId == id).ToListAsync(),
                Speakers = await _db.Speakers.ToListAsync(),
                Categories = await _db.Categories.ToListAsync(),
                Tags = await _db.Tags.ToListAsync(),
            };
            ViewBag.Speakers = eventForCreateVM.Speakers.Where(c => eventForCreateVM.SpeakerEventSimples.Any(t => t.SpeakerId == c.Id));
            return View(eventForCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, EventForCreateVM eventvm, List<int> Speakers, List<int> Tags, int Category)
        {
            EventForCreateVM eventForCreateVM = new EventForCreateVM()
            {
                EventSimple = await _db.EventSimples.Where(e => e.IsDeleted == false && e.Id == id).Include(e => e.EventDetail).FirstOrDefaultAsync(),
                EventDetail = await _db.EventDetails.Where(e => e.EventSimpleId == id).FirstOrDefaultAsync(),
                SpeakerEventSimples = await _db.SpeakerEventSimples.Where(e => e.EventSimpleId == id).ToListAsync(),
                TagEventSimples = await _db.TagEventSimples.Where(e => e.EventSimpleId == id).ToListAsync(),
                Categories = await _db.Categories.ToListAsync(),
                Tags = await _db.Tags.ToListAsync(),
                Speakers = await _db.Speakers.ToListAsync(),
            };
            EventSimple eventSimple1 = await _db.EventSimples.Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefaultAsync();
            EventDetail eventDetail = await _db.EventDetails.Where(c => c.EventSimpleId == id).FirstOrDefaultAsync();
            if (Speakers.Count() == 0)
            {
                ModelState.AddModelError("Speakers", "You need to choose at least one Speaker");
                return View(eventForCreateVM);
            }
            if (!ModelState.IsValid) return View();

            bool isExist = _db.EventSimples.Where(c => c.IsDeleted == false).Any(c => c.Title.Trim().ToLower() == eventvm.EventSimple.Title.Trim().ToLower() && c.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("", "This Event already exist");
                return View(eventForCreateVM);
            }
            if (eventvm.EventSimple.Image != null)
            {

                if (eventvm.EventSimple.Photo == null)
                {
                    ModelState.AddModelError("", "Please,add Image");
                    return View(eventForCreateVM);
                }
                if (!eventvm.EventSimple.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please,add Image file");
                    return View(eventForCreateVM);
                }
                if (!eventvm.EventSimple.Photo.MaxSize(500))
                {
                    ModelState.AddModelError("", "Max size of Image should be lower than 500");
                    return View(eventForCreateVM);
                }

                string folder = Path.Combine("img", "event");
                string fileName = await eventvm.EventSimple.Photo.SaveImagesAsync(_env.WebRootPath, folder);

                string path = Path.Combine(_env.WebRootPath, folder, eventSimple1.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                eventSimple1.Image = fileName;
            }
            eventSimple1.Title = eventvm.EventSimple.Title;
            eventSimple1.Location = eventvm.EventSimple.Location;
            eventSimple1.StartingTime = eventvm.EventSimple.StartingTime;
            eventSimple1.UpdateTime = eventvm.EventSimple.UpdateTime;
            eventDetail.AboutContent = eventvm.EventDetail.AboutContent;
            eventSimple1.CategoryId = Category;

            await _db.SaveChangesAsync();

            foreach (var s in eventForCreateVM.SpeakerEventSimples)
            {
                _db.SpeakerEventSimples.Remove(s);
            }
            foreach (var s in eventForCreateVM.TagEventSimples)
            {
                _db.TagEventSimples.Remove(s);
            }
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
        public async Task<IActionResult> LoadMore(int skip)
        {
            ViewBag.Skip = skip;
            List<EventSimple> eventSimples = await _db.EventSimples.Where(t => t.IsDeleted == false).Skip(skip).Take(10).ToListAsync();

            return PartialView("_EventPartial", eventSimples);
        }
    }
}
