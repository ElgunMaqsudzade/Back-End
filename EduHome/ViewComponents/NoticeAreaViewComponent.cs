using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;
using EduHome.ViewModels;

namespace EduHome.ViewComponents
{
    public class NoticeAreaViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public NoticeAreaViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string paddingB)
        {
            ViewBag.PaddingB = paddingB;
            HomeVM homeVM = new HomeVM()
            {
                NoticeBoards = await _db.NoticeBoards.OrderByDescending(n=>n.Id).Take(6).ToListAsync(),
                VideoTour = await _db.VideoTours.FirstOrDefaultAsync()
            };
            return View(await Task.FromResult(homeVM));
        }
    }
}
