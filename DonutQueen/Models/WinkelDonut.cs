namespace DonutQueen.Models
{
    public class WinkelDonut
    {
        public int WinkelDonutId { get; set; }
        public int Hoeveelheid { get; set; }
        public int Winkelid { get; set; }
        public Winkel Winkel { get; set; }

        public int DonutId { get; set; }
        public Donut Donut { get; set; }
    }
}
