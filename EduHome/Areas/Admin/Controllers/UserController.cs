using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static EduHome.Extensions.Extension;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {

            List<AppUser> users = _userManager.Users.ToList();
            List<UserVM> usersVM = new List<UserVM>();
            List<string> allroles = new List<string>();
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                allroles.Add(role.ToString());
            }
            foreach (AppUser user in users)
            {
                UserVM userVM = new UserVM
                {
                    Id = user.Id,
                    Fullname = user.Fullname,
                    Email = user.Email,
                    Username = user.UserName,
                    IsDeleted = user.IsDeleted,
                    Role = (await _userManager.GetRolesAsync(user))[0],
                    Roles = allroles

                };
                usersVM.Add(userVM);
            }

            return View(usersVM);
        }
        public async Task<IActionResult> Activation(string id)
        {
            AppUser userChange = await _userManager.FindByIdAsync(id);
            if (userChange.IsDeleted)
            {
                userChange.IsDeleted = false;
            }
            else
            {
                userChange.IsDeleted = true;
            }
            await _userManager.UpdateAsync(userChange);
            return RedirectToAction("Index");
        }
        public IActionResult ResetPassword(string id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, ResetPasswordVM reg)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ModelState.AddModelError("", "We coudnt find specified User");
                return View();
            }
            string passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, passwordToken, reg.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                };
                return View();
            }
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> ChangeRole(string username)
        {
            AppUser user = await _userManager.FindByNameAsync(username);
            await _userManager.GetRolesAsync(user);
            return Json(user);
        }
        //public async Task<IActionResult> ChangeRolePost(string username, string role)
        //{
        //    AppUser user = await _userManager.FindByNameAsync(username);
        //    await _userManager.RemoveFromRoleAsync(user, (await _userManager.GetRolesAsync(user))[0]);
        //    await _userManager.AddToRoleAsync(user, role);
        //    return Content(role);
        //}
    }
}
