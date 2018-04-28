using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    interface IShoppingCart
    {
        decimal CalculateTotalShoppingCart();
        void AddItemToCart(Item item);
        void RemoveItemToCart(Item item);
        void EmptyCart();
    }
}
