using DonutQueen.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DonutQueen.ViewModels
{
    public class BeschikbaarheidAanpassenViewModel
    {
        public int WinkelId { get; set; }
        public List<SelectListItem> Donuts { get; set; }

        public string Winkelnaam { get; set; }
        public int DonutId { get; set; }
        public int Hoeveelheid { get; set; }
    }
}
