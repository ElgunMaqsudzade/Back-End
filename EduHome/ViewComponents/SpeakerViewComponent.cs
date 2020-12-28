using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;

namespace EduHome.ViewComponents
{
    public class SpeakerViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public SpeakerViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Speaker> speakers = await _db.Speakers.Where(t => t.IsDeleted == false).Include(b=>b.Profession).ToListAsync();

            return View(await Task.FromResult(speakers));
        }
    }
}
