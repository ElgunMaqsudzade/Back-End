
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloLayout.ViewComponents
{
    public class SectionTitleViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public SectionTitleViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int section)
        {
            SectionTitle sectionTitle = _db.SectionTitles.Where(s=>s.Id == section).FirstOrDefault();
            return View(await Task.FromResult(sectionTitle));
        }
    }
}
