﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart;

namespace PotterShoppingCartTest
{
    [TestClass]
    public class PotterShoppingCartTest
    {
        [TestMethod]
        public void Buy_1_EP1_OrderAmount_Should_Be_100()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<HarryPotter>
            {
                new HarryPotter { Episode = "1"}
            };

            double expected = 100;

            //act
            target.checkout(books);
            double actual = target.OrderAmount;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_1_EP1_And_1_EP2_OrderAmount_Should_Be_190()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<HarryPotter>
            {
                new HarryPotter { Episode = "1"},
                new HarryPotter { Episode = "2"}
            };

            double expected = 190;

            //act
            target.checkout(books);
            double actual = target.OrderAmount;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_1_EP1_And_1_EP2_And_1_EP3_OrderAmount_Should_Be_270()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<HarryPotter>
            {
                new HarryPotter { Episode = "1"},
                new HarryPotter { Episode = "2"},
                new HarryPotter { Episode = "3"},
            };

            double expected = 270;

            //act
            target.checkout(books);
            double actual = target.OrderAmount;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
