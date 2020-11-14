using System;
using System.Collections.Generic;
using System.Text;

namespace DealerOn.Classes
{
    class SalesTaxFreeItem : IItem
    {
        public int TotalTaxes { get { if (Imported) return 5 + SalesTax; else return SalesTax; } }
        public int SalesTax { get { return 0; } }
        public decimal SalesPrice { get; set; }
        public bool Imported { get; set; }
        public string ItemDesc { get; set; }
        public SalesTaxFreeItem(string itemDesc)
        {
            ItemDesc = itemDesc;
            if (ItemDesc.Contains("Imported"))
            {
                Imported = true;
            }
            else
            {
                Imported = false;
            }
        }

        public decimal CalculateTax()
        {
            var taxes = SalesPrice * TotalTaxes / 100;
            return Math.Ceiling(taxes * 20) / 20;
        }

        public override int GetHashCode()
        {
            return ItemDesc?.GetHashCode() ?? 0;
        }
        public override bool Equals(object other)
        {
            return (other as SalesTaxFreeItem)?.ItemDesc == ItemDesc;
        }
    }
}
