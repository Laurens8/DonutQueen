using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonutQueen.Models
{
    public class Winkel
    {
        [Key]
        public int WinkelId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "De ingevulde naam is te lang. Maximale lengte is 50.")]
        public string Naam { get; set; }
        [MaxLength(100, ErrorMessage = "De ingevulde straat is te lang. Maximale lengte is 50.")]
        [Required]
        public string Straat { get; set; }
        [Required]
        public int Nummer { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "De ingevulde gemeente is te lang. Maximale lengte is 50.")]
        public string Gemeente { get; set; }
        [Required]
        public int Postcode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Telefoonnummer { get; set; }
        public ICollection<WinkelDonut> WinkelDonuts { get; set; }
    }
}