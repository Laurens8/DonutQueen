using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DonutQueen.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _uow;

        // DI injectie UOW
        public ShopController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            ShopViewModel vm = new ShopViewModel()
            {
                Donuts = _uow.DonutRepository.GetAll().ToList()
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {

            Donut donut = await _uow.DonutRepository.GetById(id);

            ShopDetailsViewModel vm = new ShopDetailsViewModel()
            {
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

    }
}