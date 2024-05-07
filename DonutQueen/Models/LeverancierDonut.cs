using System;
using System.ComponentModel.DataAnnotations;

namespace DonutQueen.Models
{
    public class LeverancierDonut
    {
        public int LeverancierDonutId { get; set; }
        public int LeverancierId { get; set; }
        public Leverancier Leverancier { get; set; }

        public int DonutId { get; set; }
        public Donut Donut { get; set; }

    }
}
