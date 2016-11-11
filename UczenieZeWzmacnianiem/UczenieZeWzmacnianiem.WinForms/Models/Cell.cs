using System.Drawing;

namespace UczenieZeWzmacnianiem.WinForms.Models
{
    public class Cell
    {
        public CellType Type { get; set; }
        public Point Coordinates { get; set; }
        public decimal Uasbility { get; set; }
    }
}