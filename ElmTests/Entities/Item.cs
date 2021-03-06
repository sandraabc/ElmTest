﻿using System;
using Entities.Interfaces;

namespace Entities
{
    public class Item : IItem
    {
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal priceFinal = 0;
                if (Product.Promo != null)
                {
                    var price = Product.Promo?.PricePromotion == 0 ? Product.Price : Product.Promo.PricePromotion;
                    priceFinal = ((Quantity / Product.Promo.TypePromotion) * price) +
                                 ((Quantity % Product.Promo.TypePromotion) * Product.Price);
                }
                else
                {
                    priceFinal = Product.Price * Quantity;
                }
                return priceFinal;
            }
        }

        public void AddMoreQuantity()
        {
            throw new NotImplementedException();
        }

        public void DeleteQuantitys()
        {
            throw new NotImplementedException();
        }
    }
}
