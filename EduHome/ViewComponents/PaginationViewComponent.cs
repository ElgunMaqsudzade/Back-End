using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;
using EduHome.Extension;

namespace EduHome.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public PaginationViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string item, int take, bool isTrue, int page)
        {
            int count = 1;
            double dbreturncount = 1;
            ViewBag.Page = page;
            ViewBag.Location = item;
            if (!isTrue)
            {
                count = 0;
            }
            else
            if (item.ToLower() == "teacher")
            {
                dbreturncount = _db.TeacherSimples.Where(t => t.IsDeleted == false).Count();
                count = dbreturncount.PaginationCount(take);
            }
            else if (item.ToLower() == "course")
            {
                dbreturncount = _db.CourseSimples.Where(t => t.IsDeleted == false).Count();
                count = dbreturncount.PaginationCount(take);
            }
            else if (item.ToLower() == "blog")
            {

                dbreturncount = _db.BlogSimples.Where(t => t.IsDeleted == false).Count();
                count = dbreturncount.PaginationCount(take);
            }
            else if (item.ToLower() == "event")
            {
                dbreturncount = _db.EventSimples.Where(t => t.IsDeleted == false).Count();
                count = dbreturncount.PaginationCount(take);
            }
            ViewBag.Take = take;
            return View(await Task.FromResult(count));
        }
    }
}
