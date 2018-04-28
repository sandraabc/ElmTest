using System.Collections.Generic;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ExampleTests.unit
{
    [TestClass]
    public class ShoppingCartTest
    {
        private readonly ShoppingCart _shoppingCart;
        private Product Product1 { get; set; }
        private Product Product2 { get; set; }
        private Product Product3 { get; set; }

        private List<Product> Products { get; set; }
        private List<Item> Items { get; set; }

        public ShoppingCartTest()
        {
            Products = new List<Product>();
            Items = new List<Item>();
            AddProducts();
            AddItems();
            _shoppingCart = new ShoppingCart { Items = Items };
        }

        [TestMethod]
        public void GetTotalAmount()
        {
            var result = _shoppingCart.CalculateTotal();

            Assert.AreEqual(result, 40);
        }

        private void AddProducts()
        {
            Product1 = new Product
            {
                ID = 1,
                Name = "A",
                Price = 20,
                Promo = new Promotions { Name = "Buy 1 Get 1 Free" }
            };

            Product2 = new Product
            {
                ID = 2,
                Name = "B",
                Price = 4,
                Promo = new Promotions { Name = "3 for 10 Euro" }
            };

            Product3 = new Product
            {
                ID = 3,
                Name = "C",
                Price = 2
            };

            Products.AddRange(new List<Product> { Product1, Product2, Product3 });
        }

        private void AddItems()
        {
            var item1 = new Item
            {
                Product = Product1,
                Quantity = 2
            };

            var item2 = new Item
            {
                Product = Product2,
                Quantity = 3
            };

            var item3 = new Item
            {
                Product = Product3,
                Quantity = 5
            };

            Items.AddRange(new List<Item> { item1, item2, item3 });
        }
    }
}
