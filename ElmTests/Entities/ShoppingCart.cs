using System.Collections.Generic;
using Entities.Interfaces;

namespace Entities
{
    public class ShoppingCart : IShoppingCart
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public decimal TotalPrice
        {
            get
            {
                decimal sum = 0;
                foreach (var item in Items)
                {
                    sum += item.TotalPrice;
                }
                return sum;
            }
            set {}
        }

        public decimal CalculateTotal()
        {
            decimal sum = 0;
            foreach (var item in Items)
            {
                sum += item.TotalPrice;
            }
            return sum;
        }
    }
}
