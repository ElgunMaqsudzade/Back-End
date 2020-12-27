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
        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<BlogSimple> blogSimples = await _db.BlogSimples.Where(t => t.IsDeleted == false).Take(take).OrderByDescending(b=>b.Id).Include(b=>b.Comments).ToListAsync();
            blogSimples.ForEach(b => b.ReplyCount = b.Comments.Count());
            await _db.SaveChangesAsync();

            return View(await Task.FromResult(blogSimples));
        }
    }
}
