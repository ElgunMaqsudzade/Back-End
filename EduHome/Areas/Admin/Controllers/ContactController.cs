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
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ContactController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            ContactVM contact = new ContactVM()
            {
                MapAddress = await _db.MapAddresses.FirstOrDefaultAsync(),
                Contacts = await _db.Contacts.ToListAsync()
            };
            return View(contact);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (contact.Photo == null)
            {
                ModelState.AddModelError("", "Please,add Image");
                return View();
            }
            if (!contact.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please,add Image file");
                return View();
            }
            if (!contact.Photo.MaxSize(500))
            {
                ModelState.AddModelError("", "Max size of Image should be lower than 500");
                return View();
            }

            string folder = Path.Combine("img", "contact");
            string fileName = await contact.Photo.SaveImagesAsync(_env.WebRootPath, folder);
            contact.Image = fileName;

            await _db.Contacts.AddAsync(contact);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.Contacts.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            Contact contact = await _db.Contacts.Where(c => c.Id == id).FirstOrDefaultAsync();
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Contact contact)
        {
            Contact contact1 = await _db.Contacts.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (contact.Photo != null)
            {
                if (!contact.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please,add Image file");
                    return View(contact1);
                }
                if (!contact.Photo.MaxSize(500))
                {
                    ModelState.AddModelError("", "Max size of Image should be lower than 500");
                    return View(contact1);
                }
                string folder = Path.Combine("img", "contact");
                string fileName = await contact.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                string path = Path.Combine(_env.WebRootPath, folder, contact1.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                contact1.Image = fileName;
            }

            contact1.Title = contact.Title;
            contact1.Address = contact.Address;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> MapUpdate(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.MapAddresses.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            MapAddress map = await _db.MapAddresses.Where(c => c.Id == id).FirstOrDefaultAsync();
            return View(map);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MapUpdate(int id, MapAddress map)
        {

            MapAddress mapAddress = await _db.MapAddresses.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (!ModelState.IsValid) return View(mapAddress);


            mapAddress.Iframe = map.Iframe;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Contact contact = _db.Contacts.Where(e => e.Id == id).FirstOrDefault();
            return Json(contact);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            Contact contacts =await _db.Contacts.Where(e => e.Id == id).FirstOrDefaultAsync();
            _db.Contacts.Remove(contacts);
            string folder = Path.Combine("img", "notice");
            string path = Path.Combine(_env.WebRootPath, folder, contacts.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            await _db.SaveChangesAsync();
            return Json(contacts);
        }
    }
}
