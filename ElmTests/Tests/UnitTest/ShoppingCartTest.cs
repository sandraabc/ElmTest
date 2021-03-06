﻿using System.Collections.Generic;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests.UnitTest
{
    [TestClass]
    public class ShoppingCartTest
    {
        private readonly ShoppingCart _shoppingCart;
        private Product Product1 { get; set; }
        private Product Product2 { get; set; }
        private Product Product3 { get; set; }
        private Product Product { get; set; }

        private List<Product> Products { get; set; }
        private List<Item> Items { get; set; }

        public ShoppingCartTest()
        {
            Products = new List<Product>();
            Items = new List<Item>();
            AddProducts();
            _shoppingCart = new ShoppingCart ();
        }

        [TestMethod]
        public void GetTotalAmount()
        {
            _shoppingCart.Items = AddItems(2, 3, 5); ;
            var result = _shoppingCart.CalculateTotalShoppingCart();

            Assert.AreEqual(result, 40);
        }

        [TestMethod]
        public void GetTotalAmount_OtherQuantities()
        {
            _shoppingCart.Items = AddItems(1, 8, 5); ;
            var result = _shoppingCart.CalculateTotalShoppingCart();

            Assert.AreEqual(result, 58);
        }

        [TestMethod]
        public void AddExistingItem()
        {
            _shoppingCart.Items = AddItems(2, 3, 5);
            var currentItems = _shoppingCart.Items.Count;
            _shoppingCart.AddItemToCart(AddOneItem(1));

            Assert.AreEqual(_shoppingCart.Items.Count, currentItems);
        }

        [TestMethod]
        public void AddNewItem()
        {
            _shoppingCart.Items = AddItems(2, 3, 5);
            var currentItems = _shoppingCart.Items.Count;
            _shoppingCart.AddItemToCart(AddOneItem(5));

            Assert.AreEqual(_shoppingCart.Items.Count, currentItems + 1);
        }

        [TestMethod]
        public void DeleteExistingItem()
        {
            _shoppingCart.Items = AddItems(2, 3, 5);
            var currentItems = _shoppingCart.Items.Count;
            _shoppingCart.RemoveItemToCart(AddOneItem(1));

            Assert.AreEqual(_shoppingCart.Items.Count, currentItems - 1);
        }

        [TestMethod]
        public void DeleteNotExistingItem()
        {
            _shoppingCart.Items = AddItems(2, 3, 5);
            var currentItems = _shoppingCart.Items.Count;
            _shoppingCart.RemoveItemToCart(AddOneItem(5));

            Assert.AreEqual(_shoppingCart.Items.Count, currentItems);
        }

        private void AddProducts()
        {
            Product1 = new Product
            {
                ID = 1,
                Name = "A",
                Price = 20,
                Promo = new Promotions { Id = 1, Name = "Buy 1 Get 1 Free", TypePromotion = 2, PricePromotion = 0 }
            };

            Product2 = new Product
            {
                ID = 2,
                Name = "B",
                Price = 4,
                Promo = new Promotions { Id = 2, Name = "3 for 10 Euro", TypePromotion = 3, PricePromotion = 10 }
            };

            Product3 = new Product
            {
                ID = 3,
                Name = "C",
                Price = 2
            };

            Products.AddRange(new List<Product> { Product1, Product2, Product3 });
        }

        private List<Item> AddItems(int quantity1, int quantity2, int quantity3)
        {
            var item1 = new Item
            {
                Product = Product1,
                Quantity = quantity1
            };

            var item2 = new Item
            {
                Product = Product2,
                Quantity = quantity2
            };

            var item3 = new Item
            {
                Product = Product3,
                Quantity = quantity3
            };

            return new List<Item> { item1, item2, item3 };
        }

        private Item AddOneItem(int productId)
        {
            var item = new Item
            {
                Product = new Product
                {
                    ID = productId,
                    Name = "A",
                    Price = 20,
                    Promo = new Promotions { Id = 1, Name = "Buy 1 Get 1 Free", TypePromotion = 2, PricePromotion = 0 }
                },
                Quantity = 2
            };

            return item;
        }
    }
}
