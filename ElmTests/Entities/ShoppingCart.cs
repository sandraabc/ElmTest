using System.Collections.Generic;
using System.Linq;
using Entities.Interfaces;

namespace Entities
{
    public class ShoppingCart : IShoppingCart
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public decimal CalculateTotalShoppingCart()
        {
            decimal sum = 0;
            foreach (var item in Items)
            {
                sum += item.TotalPrice;
            }
            return sum;
        }

        public void AddItemToCart(Item item)
        {
            if (Items.Find(x => x.Product.ID == item.Product.ID) == null)
                this.Items.Add(item);
        }

        public void RemoveItemToCart(Item item)
        {
            var itemToDelete = Items.Find(x => x.Product.ID == item.Product.ID);
            if (itemToDelete != null)
                this.Items.Remove(itemToDelete);
        }

        public void EmptyCart()
        {
            this.Items.Clear();
        }
    }
}
