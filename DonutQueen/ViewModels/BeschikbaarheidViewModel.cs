using System.Collections.Generic;
using DonutQueen.Models;

namespace DonutQueen.ViewModels
{
    public class BeschikbaarheidViewModel
    {
        public string Winkelnaam { get; set; }
        public List<WinkelDonut> WinkelDonuts { get; set; }
    }
}
