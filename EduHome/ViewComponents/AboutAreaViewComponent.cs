﻿using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;

namespace EduHome.ViewComponents
{
    public class AboutAreaViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public AboutAreaViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string paddingT)
        {
            ViewBag.PaddingT = paddingT;
            AboutArea about = await _db.AboutAreas.Where(a=>a.Updated==false).FirstOrDefaultAsync();
            return View(about);
        }
    }
}
