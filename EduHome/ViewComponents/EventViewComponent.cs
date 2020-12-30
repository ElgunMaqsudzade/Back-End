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
        public async Task<IViewComponentResult> InvokeAsync(int take,string category ,int page)
        {
            bool isExist = _db.Categories.Any(t => t.Name == category);
            if (isExist)
            {
                List<EventSimple> eventSimples = await _db.EventSimples.Where(t => t.IsDeleted == false && t.Category.Name.Contains(category))
                    .OrderByDescending(b => b.Id).Include(t => t.Category).ToListAsync();
                return View(await Task.FromResult(eventSimples));
            }
            else
            {
                List<EventSimple> eventSimples = await _db.EventSimples.Where(t => t.IsDeleted == false).Skip(take * (page - 1)).Take(take).OrderByDescending(b => b.Id).Include(b => b.Comments).ToListAsync();
                return View(await Task.FromResult(eventSimples));
            }
        }
    }
}
