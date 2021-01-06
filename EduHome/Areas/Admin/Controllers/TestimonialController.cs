using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduHome.DAL;
using EduHome.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using EduHome.Extensions;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TestimonialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/TestimonialAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestimonialAreas.Where(t=>t.IsDeleted == false).ToListAsync());
        }

        // GET: Admin/TestimonialAreas/Details/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonialArea = await _context.TestimonialAreas.Where(t => t.IsDeleted == false)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testimonialArea == null)
            {
                return NotFound();
            }

            return View(testimonialArea);
        }

        // GET: Admin/TestimonialAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestimonialArea testimonialArea)
        {
            List<TestimonialArea> testimonial = await _context.TestimonialAreas.Where(t => t.IsDeleted == false).ToListAsync();
            if (ModelState.IsValid)
            {
                if (testimonialArea.Photo == null)
                {
                    ModelState.AddModelError("", "Please,add Image");
                    return View();
                }
                if (!testimonialArea.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please,add Image file");
                    return View();
                }
                if (!testimonialArea.Photo.MaxSize(500))
                {
                    ModelState.AddModelError("", "Max size of Image should be lower than 500");
                    return View();
                }

                string folder = Path.Combine("img", "testimonial");
                string fileName = await testimonialArea.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                testimonialArea.Image = fileName;
                await _context.AddAsync(testimonialArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testimonialArea);
        }

        // GET: Admin/TestimonialAreas/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestimonialArea testimonialArea = await _context.TestimonialAreas.FirstOrDefaultAsync(t => t.Id == id);
            if (testimonialArea == null)
            {
                return NotFound();
            }
            return View(testimonialArea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TestimonialArea testimonialArea)
        {
            if (id != testimonialArea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TestimonialArea testimonial = await _context.TestimonialAreas.Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefaultAsync();

                    if (testimonialArea.Photo != null)
                    {
                        if (!testimonialArea.Photo.IsImage())
                        {
                            ModelState.AddModelError("", "Please,add Image file");
                            return View(testimonial);
                        }
                        if (!testimonialArea.Photo.MaxSize(500))
                        {
                            ModelState.AddModelError("", "Max size of Image should be lower than 500");
                            return View(testimonial);
                        }
                        string folder = Path.Combine("img", "testimonial");
                        string fileName = await testimonialArea.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                        string path = Path.Combine(_env.WebRootPath, folder, testimonial.Image);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        testimonial.Image = fileName;
                    }

                    testimonial.Fullname = testimonialArea.Fullname;
                    testimonial.Description = testimonialArea.Description;
                    testimonial.UpdateTime = DateTime.UtcNow;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialAreaExists(testimonialArea.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testimonialArea);
        }

        public IActionResult Delete(int id)
        {
            TestimonialArea notice = _context.TestimonialAreas.Where(e => e.Id == id).FirstOrDefault();
            return Json(notice);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            List<TestimonialArea> notices = _context.TestimonialAreas.ToList();
            if (notices.Count() > 0)
            {
                notices.Where(e => e.Id == id).FirstOrDefault().IsDeleted = true;
                notices.Where(e => e.Id == id).FirstOrDefault().DeleteTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return Json(notices);
        }

        private bool TestimonialAreaExists(int id)
        {
            return _context.TestimonialAreas.Any(e => e.Id == id);
        }
    }
}
