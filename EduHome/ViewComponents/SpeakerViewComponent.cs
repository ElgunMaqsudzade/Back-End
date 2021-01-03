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
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Speaker> speakers1 = await _db.Speakers.Where(t => t.IsDeleted == false)
                .Include(s => s.SpeakerEventSimples).ThenInclude(s => s.EventSimple).Include(b => b.Profession).ToListAsync();

            List<Speaker> speakers2 = (from spe in speakers1
                                       from category in spe.SpeakerEventSimples.Where(x => x.EventSimple.Id == id)
                                       select spe).ToList();

            return View(await Task.FromResult(speakers2));
        }
    }
}