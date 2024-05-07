using DonutQueen.Areas.Identity.Data;
using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WinkelDonut = DonutQueen.Models.WinkelDonut;

namespace DonutQueen.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _uow;

        // DI injectie UOW
        public AdminController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Donuts()
        {
            DonutOverviewViewModel vm = new DonutOverviewViewModel()
            {
                Donuts = _uow.DonutRepository.GetAll().ToList()
            };

            return View(vm);
        }

        public async Task<IActionResult> DonutDetails(int id)
        {
            Donut donut = await _uow.DonutRepository.GetById(id);
            if (donut != null)
            {
                DonutDetailsViewModel vm = new DonutDetailsViewModel()
                {
                    DonutId = id,
                    Naam = donut.Naam,
                    Topping = donut.Topping,
                    Glazuur = donut.Glazuur,
                    Vulling = donut.Vulling,
                    Omschrijving = donut.Omschrijving,
                    IsVegan = donut.IsVegan,
                    Afbeelding = donut.Afbeelding,
                    Prijs = donut.Prijs
                };

                return View(vm);
            }
            else
            {
                DonutOverviewViewModel vm = new DonutOverviewViewModel()
                {
                    Donuts = _uow.DonutRepository.GetAll().ToList()
                };
                return View("Index", vm);
            }
        }

        [HttpGet]
        public IActionResult CreateDonut()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDonut(CreateDonutViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Donut donut = new Donut()
                {
                    Naam = viewModel.Naam,
                    Topping = viewModel.Topping,
                    Glazuur = viewModel.Glazuur,
                    Vulling = viewModel.Vulling,
                    Omschrijving = viewModel.Omschrijving,
                    IsVegan = viewModel.IsVegan,
                    Afbeelding = viewModel.Afbeelding,
                    Prijs = viewModel.Prijs
                };
                _uow.DonutRepository.Create(donut);
                await _uow.Save();
                return RedirectToAction(nameof(Donuts));
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditDonut(int? id)
        {
            if (id == null)
                return NotFound();

            int meegegevenId = (int)((id != null) ? id : 0);
            Donut donut = await _uow.DonutRepository.GetById(meegegevenId);

            if (donut == null)
                return NotFound();

            EditDonutViewModel vm = new EditDonutViewModel()
            {
                DonutId = donut.DonutId,
                Naam = donut.Naam,
                Topping = donut.Topping,
                Glazuur = donut.Glazuur,
                Vulling = donut.Vulling,
                Omschrijving = donut.Omschrijving,
                IsVegan = donut.IsVegan,
                Afbeelding = donut.Afbeelding,
                Prijs = donut.Prijs
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDonut(int id, EditDonutViewModel viewModel)
        {
            if (id != viewModel.DonutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Donut donut = new Donut()
                    {
                        DonutId = viewModel.DonutId,
                        Naam = viewModel.Naam,
                        Topping = viewModel.Topping,
                        Glazuur = viewModel.Glazuur,
                        Vulling = viewModel.Vulling,
                        Omschrijving = viewModel.Omschrijving,
                        IsVegan = viewModel.IsVegan,
                        Afbeelding = viewModel.Afbeelding,
                        Prijs = viewModel.Prijs
                    };
                    _uow.DonutRepository.Update(donut);
                    await _uow.Save();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (_uow.DonutRepository.GetById(viewModel.DonutId) == null)
                        return NotFound();
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Donuts));
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDonut(int id)
        {
            Donut donut = await _uow.DonutRepository.GetById(id);
            if (donut != null)
            {
                DeleteDonutViewModel vm = new DeleteDonutViewModel()
                {
                    DonutId = id,
                    Naam = donut.Naam,
                    Topping = donut.Topping,
                    Glazuur = donut.Glazuur,
                    Vulling = donut.Vulling,
                    Omschrijving = donut.Omschrijving,
                    IsVegan = donut.IsVegan,
                    Afbeelding = donut.Afbeelding,
                    Prijs = donut.Prijs
                };

                return View(vm);
            }
            else
            {
                DonutOverviewViewModel vm = new DonutOverviewViewModel()
                {
                    Donuts = _uow.DonutRepository.GetAll().ToList()
                };
                return View("Index", vm);
            }
        }

        [HttpPost, ActionName("DeleteDonut")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDonutConfirm(int id)
        {
            Donut donut = await _uow.DonutRepository.GetById(id);
            _uow.DonutRepository.Delete(donut);
            await _uow.Save();
            return RedirectToAction(nameof(Donuts));
        }

        public IActionResult LeverancierLijst()
        {
            LeverancierOverviewViewModel vm = new LeverancierOverviewViewModel()
            {
                Leveranciers = _uow.LeverancierRepository.GetAll().ToList()
            };

            return View(vm);
        }

        public IActionResult DonutPerLeverancier()
        {
            //  In view binnen de associatie-info, hebben we Leverancier & Donut object nodig
            var ld = _uow.LeverancierDonutRepository.GetAll(x => x.Leverancier, y => y.Donut).ToList();
            DonutsPerLeverancierViewModel pdvm = new DonutsPerLeverancierViewModel();
            pdvm.LeverancierDonuts = ld;

            return View(pdvm);
        }

        public IActionResult Winkels()
        {
            WinkelOverviewViewModel vm = new WinkelOverviewViewModel()
            {
                Winkels = _uow.WinkelRepository.GetAll().ToList()
            };

            return View(vm);
        }

        public IActionResult Gebruikers()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BeschikbaarheidAanpassen(int id, BeschikbaarheidAanpassenViewModel vm)
        {

            Winkel winkel = await _uow.WinkelRepository.GetById(id);

            if (winkel != null)
            {
                vm.WinkelId = id;
                vm.Winkelnaam = winkel.Naam;
                 
                vm.Donuts = new List<SelectListItem>();
                foreach (var p in _uow.DonutRepository.GetAll())
                {
                    if (vm.DonutId == p.DonutId)
                    {
                        vm.Donuts.Add(new SelectListItem() { Text = p.Naam, Value = p.DonutId.ToString(), Selected = true });

                        WinkelDonut wd = _uow.WinkelDonutRepository.GetAll().Where(d => d.Winkelid == id && d.DonutId == p.DonutId).FirstOrDefault();

                        if (wd != null)
                        { vm.Hoeveelheid = wd.Hoeveelheid; }
                        else
                        { vm.Hoeveelheid = 0; }
                     }
                    else
                    {
                        vm.Donuts.Add(new SelectListItem() { Text = p.Naam, Value = p.DonutId.ToString(), Selected = false });
                    }

                }
                return View(vm);
            }
            else
            { 
            WinkelOverviewViewModel viewmodel = new WinkelOverviewViewModel()
            {
                Winkels = _uow.WinkelRepository.GetAll().ToList()
            };

            return View("Winkels",viewmodel);
            }

        }

        [HttpPost]

        public async Task<IActionResult> BeschikbaarheidAanpassen(BeschikbaarheidAanpassenViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WinkelDonut wd = _uow.WinkelDonutRepository.GetAll().Where(d => d.Winkelid == vm.WinkelId && d.DonutId == vm.DonutId).FirstOrDefault();

                    if (wd != null)
                    {   wd.Hoeveelheid = vm.Hoeveelheid;
                        _uow.WinkelDonutRepository.Update(wd);
                    }
                    else
                    {
                        WinkelDonut winkeldonut = new WinkelDonut()
                        {
                            Winkelid = vm.WinkelId,
                            DonutId = vm.DonutId,
                            Hoeveelheid = vm.Hoeveelheid

                        };
                        _uow.WinkelDonutRepository.Update(winkeldonut);
                    }
                    await _uow.Save();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_uow.WinkelDonutRepository.GetAll().Any(d => d.DonutId == vm.DonutId && d.Winkelid == vm.WinkelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Winkels));
            }
            return View(vm);
        }
    }
}