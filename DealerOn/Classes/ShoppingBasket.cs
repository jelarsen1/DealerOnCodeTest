using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace DealerOn.Classes
{
    class ShoppingBasket
    {
        public Dictionary<IItem, int> Basket { get; set; }

        public ShoppingBasket(string shoppingList)
        {
            Basket = new Dictionary<IItem, int>();
            ProcessList(shoppingList);
        }

        private void ProcessList(string shoppingList)
        {            
            Regex reg = new Regex(@"(\d+)\s(.*?)\sat\s(\d+\.\d{2})");

            foreach(Match match in reg.Matches(shoppingList))
            {
                var salesPrice = decimal.Parse(match.Groups[3].ToString());
                var itemDesc = match.Groups[2].ToString();
                var itemQty = int.Parse(match.Groups[1].ToString());

                IItem item = Factory.GetItem(itemDesc);
                item.SalesPrice = salesPrice;

                if (Basket.ContainsKey(item))
                {
                    Basket[item] += itemQty;
                }
                else
                {
                    Basket.Add(item, itemQty);
                }
            }
        }

        public string CreateList()
        {
            StringBuilder sb = new StringBuilder();
            decimal totalTaxes = 0;
            decimal totalSales = 0;

            foreach (KeyValuePair<IItem, int> pair in Basket)
            {
                decimal priceWithTax = pair.Key.CalculateTax() + pair.Key.SalesPrice;
                decimal allPricesWithTax = priceWithTax * pair.Value;
                sb.Append($"{pair.Key.ItemDesc}: {allPricesWithTax.ToString("0.00")} ({pair.Value} @ {priceWithTax.ToString("0.00")})\r\n");
                totalTaxes += pair.Key.CalculateTax() * pair.Value;
                totalSales += allPricesWithTax;
            }
            sb.Append($"Sales Taxes: {totalTaxes.ToString("0.00")}\r\n");
            sb.Append($"Total: {totalSales.ToString("0.00")}");

            return sb.ToString();
        }

    }
}
