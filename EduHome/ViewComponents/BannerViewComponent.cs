
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloLayout.ViewComponents
{
    public class BannerViewComponent: ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync(string word)
        {
            ViewBag.BreadCrumb= word;
            return View();
        }
    }
}
