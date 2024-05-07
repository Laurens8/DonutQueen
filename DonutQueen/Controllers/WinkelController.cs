using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DonutQueen.Controllers
{
    public class WinkelController : Controller
    {
        private readonly IUnitOfWork _uow;

        // DI injectie UOW
        public WinkelController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            WinkelsViewModel vm = new WinkelsViewModel()
            {
                Winkels = _uow.WinkelRepository.GetAll().ToList()
            };

            return View(vm);
        }
        public IActionResult Beschikbaarheid(int id)
        {
            BeschikbaarheidViewModel viewModel = new BeschikbaarheidViewModel();

            viewModel.WinkelDonuts = _uow.WinkelDonutRepository.GetAll(x => x.Donut, y => y.Winkel).Where(z => z.Winkelid == id).ToList();
            viewModel.Winkelnaam = _uow.WinkelRepository.GetAll().Where(a => a.WinkelId == id).FirstOrDefault().Naam;
            return View(viewModel);
        }
    }
}