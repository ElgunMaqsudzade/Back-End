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
        public async Task<IViewComponentResult> InvokeAsync(int take, int tagId)
        {
            bool isExist = _db.Tags.Any(t => t.Id == tagId);
            if (isExist)
            {
                List<BlogSimple> blogSimples1 = new List<BlogSimple>();
                List<BlogSimple> blogSimples = await _db.BlogSimples.Where(t => t.IsDeleted == false).OrderByDescending(b => b.Id).Include(t => t.TagBlogSimples).ThenInclude(t => t.Tag).Include(b => b.Comments).ToListAsync();
                foreach (var blog in blogSimples)
                {
                    foreach (var item in blog.TagBlogSimples.Where(t => t.TagId == tagId).ToList())
                    {
                        blogSimples1.Add(blog);
                    }
                   
                }
                blogSimples.ForEach(b => b.ReplyCount = b.Comments.Count());
                await _db.SaveChangesAsync();
                return View(await Task.FromResult(blogSimples1));
            }
            else
            {
                List<BlogSimple> blogSimples = await _db.BlogSimples.Where(t => t.IsDeleted == false).Take(take).OrderByDescending(b => b.Id).Include(b => b.Comments).ToListAsync();
                blogSimples.ForEach(b => b.ReplyCount = b.Comments.Count());
                await _db.SaveChangesAsync();
                return View(await Task.FromResult(blogSimples));
            }
        }
    }
}
