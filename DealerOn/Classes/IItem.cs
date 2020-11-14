using System;
using System.Collections.Generic;
using System.Text;

namespace DealerOn.Classes
{
    public interface IItem
    {
        public int TotalTaxes { get; }
        public int SalesTax { get; }
        public decimal SalesPrice { get; set; }
        public bool Imported { get; set; }
        public string ItemDesc { get; set; }
        public decimal CalculateTax();
    }
}
