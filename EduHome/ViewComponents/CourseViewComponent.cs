﻿using EduHome.DAL;
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
    public class CourseViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public CourseViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string location,string keyword, string category,int page ,int take)
        {
            bool isExist = _db.Categories.Any(t => t.Name == category);
            if (isExist)
            {
                List<CourseSimple> courseSimples = await _db.CourseSimples.Where(t => t.IsDeleted == false && t.Category.Name.Contains(category))
                    .OrderByDescending(b => b.Id).Include(t => t.Category).ToListAsync();
                return View(await Task.FromResult(courseSimples));
            }
            else if (location == "Home")
            {
                List<CourseSimple> courseSimples = await _db.CourseSimples.Where(t => t.IsDeleted == false && t.IsSimple == true).ToListAsync();
                return View(await Task.FromResult(courseSimples));
            }
            else if (location == "search" && keyword != null)
            {
                List<CourseSimple> courseSimples = await _db.CourseSimples.Where(t => t.IsDeleted == false && t.Title.Trim().ToLower().Contains(keyword)).ToListAsync();
                return View(await Task.FromResult(courseSimples));
            }
            else
            {
                List<CourseSimple> courseSimples = await _db.CourseSimples.Where(t => t.IsDeleted == false).Skip(take * (page - 1)).Take(take).ToListAsync();
                return View(await Task.FromResult(courseSimples));
            }
        }
    }
}
