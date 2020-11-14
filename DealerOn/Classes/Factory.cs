using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DealerOn.Classes
{
    public static class Factory
    {
        private static readonly List<string> SalesTaxFreeItems = new List<string>(){ "Book", "Chocolate bar", "Imported box of chocolates", "Packet of headache pills" };
        public static IItem GetItem(string itemDesc)
        {
            if (SalesTaxFreeItems.Contains(itemDesc))
            {
                return new SalesTaxFreeItem(itemDesc);
            }
            return new RegularItem(itemDesc);
        }
    }
}
