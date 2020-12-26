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
    public class BlogViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public BlogViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int take,int col)
        {
            ViewBag.Col = col;
            List<BlogSimple> blogSimples = await _db.BlogSimples.Where(t => t.IsDeleted == false).Take(take).OrderByDescending(b=>b.Id).ToListAsync();
            return View(await Task.FromResult(blogSimples));
        }
    }
}
