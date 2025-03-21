﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanale2_BU2.Models;
using ProgettoSettimanale2_BU2.ViewModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale2_BU2.Data;

namespace ProgettoSettimanale2_BU2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        private bool verifyAuth()
        {
            return User.Identity.IsAuthenticated;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate
                };

                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

                var user = await _userManager.FindByEmailAsync(newUser.Email);

                var role = model.Role ?? "Dipendente";
                var addRoleResult = await _userManager.AddToRoleAsync(user, role);

                if (!addRoleResult.Succeeded)
                {
                    foreach (var error in addRoleResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (verifyAuth())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email o password non validi.");
                return View(model);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email o password non validi.");
                return View(model);
            }
            var roles = await _signInManager.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>();

            var nameClaim = new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}");

            var emailClaim = new Claim(ClaimTypes.Email, user.Email);

            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }

            claims.Add(nameClaim);
            claims.Add(emailClaim);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.IsDeleted = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AccountList()
        {
            var users = _userManager.Users.ToList();
            var userRoles = new List<Tuple<ApplicationUser, IEnumerable<string>>>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles.Add(new Tuple<ApplicationUser, IEnumerable<string>>(user, roles));
            }

            ViewBag.UserRoles = userRoles;

            return View(users);
        }
    }
}
