using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace UczenieZeWzmacnianiem.WinForms.Models
{
    public class Cell
    {
        public Cell()
        {
            Usabilities = new List<decimal>();
        }

        public CellType Type { get; set; }
        public Point Coordinates { get; set; }

        public decimal Uasbility
        {
            get { return Usabilities.Count > 0 ? Usabilities.Average() : Decimal.Zero; }
        }

        public List<decimal> Usabilities { get; private set; }
    }
}