using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DonutQueen.Models
{
    public class Leverancier
    {

        public int LeverancierId { get; set; }
        [Required(ErrorMessage ="Gelieve een Leveranciersnaam in te vullen aub."),MaxLength(50,ErrorMessage ="De ingevulde naam is te lang. Maximale lengte is 50.")]
        public string LeveranciersNaam { get; set; }
        public string VoornaamContact { get; set; }
        public string FamilienaamContact { get; set; }
        [Required(ErrorMessage = "Gelieve een emailadres in te vullen aub.")]
        public string Emailadres { get; set; }
        [Required(ErrorMessage = "Gelieve een straat in te vullen aub."),MaxLength(100,ErrorMessage = "De ingevulde straat is te lang. Maximale lengte is 50.")]
        public string Straat { get; set; }
        [Required(ErrorMessage = "Gelieve een huisnummer in te vullen aub.")]
        public int Huisnummer { get; set; }
        [Required(ErrorMessage = "Gelieve een postcode in te vullen aub.")]
        public int Postcode { get; set; }


        public ICollection<LeverancierDonut> LeverancierDonuts { get; set; }
    }
}
