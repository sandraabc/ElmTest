using System;

namespace Entities
{
    public class Item
    {
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal priceFinal = 0;
                switch (Product.Promo?.Id)
                {
                    case 1:
                        priceFinal = ((Quantity / 2) * Product.Price) + ((Quantity % 2) * Product.Price);
                        break;
                    case 2:
                        priceFinal = ((Quantity / 3) * 10 ) + ((Quantity % 3) * Product.Price);
                        break;
                    default:
                        priceFinal = Quantity * Product.Price;
                        break;
                }

                return priceFinal;
            }
            set { }
        }
    }
}
