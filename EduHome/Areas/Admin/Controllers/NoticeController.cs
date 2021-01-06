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
    public class NoticeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public NoticeController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                VideoTour = await _db.VideoTours.FirstOrDefaultAsync(),
                NoticeBoards = await _db.NoticeBoards.ToListAsync()
            };
            return View(homeVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticeBoard notice)
        {
            await _db.NoticeBoards.AddAsync(notice);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.NoticeBoards.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            NoticeBoard notice = await _db.NoticeBoards.Where(c => c.Id == id).FirstOrDefaultAsync();
            return View(notice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, NoticeBoard notice)
        {
            NoticeBoard noticeBoard = await _db.NoticeBoards.Where(c => c.Id == id).FirstOrDefaultAsync();

            noticeBoard.NoticeDate = DateTime.UtcNow;
            noticeBoard.Descriptioon = notice.Descriptioon;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> VideoUpdate(int? id)
        {
            if (id == null) return NotFound();
            bool isExist = _db.VideoTours.Any(c => c.Id == id);
            if (!isExist) return NotFound();
            VideoTour video = await _db.VideoTours.Where(c => c.Id == id).FirstOrDefaultAsync();
            return View(video);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VideoUpdate(int id, VideoTour video)
        {

            VideoTour videoTour = await _db.VideoTours.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (!ModelState.IsValid) return View(videoTour);

            if (video.Photo != null)
            {
                if (!video.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please,add Image file");
                    return View(videoTour);
                }
                if (!video.Photo.MaxSize(500))
                {
                    ModelState.AddModelError("", "Max size of Image should be lower than 500");
                    return View(videoTour);
                }
                string folder = Path.Combine("img", "notice");
                string fileName = await video.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                string path = Path.Combine(_env.WebRootPath, folder, videoTour.Image);
                videoTour.Image = fileName;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            videoTour.VideoLink = video.VideoLink;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            NoticeBoard notice = _db.NoticeBoards.Where(e => e.Id == id).FirstOrDefault();
            return Json(notice);
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            NoticeBoard notice = await _db.NoticeBoards.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (_db.NoticeBoards.Count() > 1)
            {
                _db.NoticeBoards.Remove(notice);
            }
            else
            {
                return NotFound();
            }
            await _db.SaveChangesAsync();
            return Json(notice);
        }
    }
}
