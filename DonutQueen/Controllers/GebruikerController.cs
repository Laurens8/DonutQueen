using DonutQueen.Areas.Identity.Data;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DonutQueen.Controllers
{
    [Authorize(Roles ="admin")]
    public class GebruikerController : Controller
    {
        private UserManager<CustomUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public GebruikerController(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            GebruikerListViewModel viewModel = new GebruikerListViewModel()
            {
                Gebruikers = _userManager.Users.ToList()

            };
            return View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            CustomUser gebruiker =  _userManager.Users.Where(k => k.Id == id).FirstOrDefault();

            
            if (gebruiker != null)
            {
                GebruikerEditViewModel viewModel = new GebruikerEditViewModel()
                {
                    GebruikerId = gebruiker.Id,
                    Naam = gebruiker.Naam,
                    Voornaam = gebruiker.Voornaam,
                    Email = gebruiker.UserName,
                    Geboortedatum = gebruiker.Geboortedatum,
 
                };
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GebruikerEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CustomUser gebruiker = await _userManager.FindByIdAsync(viewModel.GebruikerId);

                gebruiker.Naam = viewModel.Naam;
                gebruiker.Voornaam = viewModel.Voornaam;
                gebruiker.Geboortedatum = viewModel.Geboortedatum;
                gebruiker.Email = viewModel.Email;
                
                IdentityResult result = await _userManager.UpdateAsync(gebruiker);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }

        public IActionResult Create()
        {
            GebruikerCreateViewModel viewModel = new GebruikerCreateViewModel()
            {
                Geboortedatum = new DateTime(1950, 1, 1),
                Rollen = new SelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GebruikerCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CustomUser gebruiker = new CustomUser
                {
                    Naam = viewModel.Naam,
                    Voornaam = viewModel.Voornaam,
                    Geboortedatum = viewModel.Geboortedatum,
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };

                IdentityResult result = await _userManager.CreateAsync(gebruiker, viewModel.Password);

                if (result.Succeeded)
                {
                    CustomUser user = await _userManager.FindByEmailAsync(viewModel.Email);
                    IdentityRole role = await _roleManager.FindByIdAsync(viewModel.RolId);

                    IdentityResult Resultaat = await _userManager.AddToRoleAsync(user, role.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Delete(string id)
        {
            CustomUser user = await _userManager.FindByIdAsync(id);
   
            if (user == null)
            {
                return NotFound();
            }

            GebruikerDeleteViewModel viewModel = new GebruikerDeleteViewModel()
            {
                GebruikerId = id,
                Voornaam = user.Voornaam,
                Naam = user.Naam
            };
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
            {
            CustomUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", _userManager.Users.ToList());
        }

        //[AllowAnonymous]
        public IActionResult GrantPermissions()
        {
            GrantPermissionViewModel viewModel = new GrantPermissionViewModel()
            {
                Gebruikers = new SelectList(_userManager.Users.ToList(), "Id", "UserName"),
                Rollen = new SelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };
            return View(viewModel);
        }

        //[AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GrantPermissions(GrantPermissionViewModel viewModel)
        {                                                 
            if (ModelState.IsValid)
            {
                CustomUser user = await _userManager.FindByIdAsync(viewModel.GebruikerId);
                IdentityRole role = await _roleManager.FindByIdAsync(viewModel.RolId);
                if (user != null && role != null)
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                    }
                }
                else
                    ModelState.AddModelError("", "User or role Not Found");
            }
            return View(viewModel);
        }

    }
    
}
