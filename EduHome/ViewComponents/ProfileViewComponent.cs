using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;
using EduHome.Extensions;
using Microsoft.AspNetCore.Identity;

namespace EduHome.ViewComponents
{
    public class ProfileViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public ProfileViewComponent(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(await Task.FromResult(appUser));
        }
    }
}
