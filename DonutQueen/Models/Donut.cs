using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonutQueen.Models
{
    public class Donut
    {
        public int DonutId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "De ingevulde naam is te lang. Maximale lengte is 50.")]
        public string Naam { get; set; }

        [Required]
        public string Topping { get; set; }

        [Required]
        public string Glazuur { get; set; }

        [Required]
        public string Vulling { get; set; }

        public string Omschrijving { get; set; }

        [Required]
        public bool IsVegan { get; set; }

        [Required]
        public string Afbeelding { get; set; }

        public Decimal Prijs { get; set; }

        public ICollection<LeverancierDonut> LeverancierDonuts { get; set; }
        public ICollection<WinkelDonut> WinkelDonuts { get; set; }
    }
}