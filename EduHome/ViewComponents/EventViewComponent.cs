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
    public class EventViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public EventViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<EventSimple> eventSimples = await _db.EventSimples.Where(t => t.IsDeleted == false).Take(take).OrderByDescending(b => b.Id).Include(b => b.Comments).ToListAsync();
            return View(await Task.FromResult(eventSimples));
        }
    }
}
