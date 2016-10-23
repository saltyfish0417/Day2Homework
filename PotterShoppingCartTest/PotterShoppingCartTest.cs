using System;
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

        [TestMethod]
        public void Buy_1_EP1_And_1_EP2_And_1_EP3_And_1_EP4_OrderAmount_Should_Be_320()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<HarryPotter>
            {
                new HarryPotter { Episode = "1"},
                new HarryPotter { Episode = "2"},
                new HarryPotter { Episode = "3"},
                new HarryPotter { Episode = "4"},
            };

            double expected = 320;

            //act
            target.checkout(books);
            double actual = target.OrderAmount;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_1_EP1_And_1_EP2_And_1_EP3_And_1_EP4_And_1_EP5_OrderAmount_Should_Be_375()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<HarryPotter>
            {
                new HarryPotter { Episode = "1"},
                new HarryPotter { Episode = "2"},
                new HarryPotter { Episode = "3"},
                new HarryPotter { Episode = "4"},
                new HarryPotter { Episode = "5"},
            };

            double expected = 375;

            //act
            target.checkout(books);
            double actual = target.OrderAmount;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_1_EP1_And_1_EP2_And_2_EP3_OrderAmount_Should_Be_370()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<HarryPotter>
            {
                new HarryPotter { Episode = "1"},
                new HarryPotter { Episode = "2"},
                new HarryPotter { Episode = "3"},
                new HarryPotter { Episode = "3"},
            };

            double expected = 370;

            //act
            target.checkout(books);
            double actual = target.OrderAmount;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_1_EP1_And_2_EP2_And_2_EP3_OrderAmount_Should_Be_460()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<HarryPotter>
            {
                new HarryPotter { Episode = "1"},
                new HarryPotter { Episode = "2"},
                new HarryPotter { Episode = "2"},
                new HarryPotter { Episode = "3"},
                new HarryPotter { Episode = "3"},
            };

            double expected = 460;

            //act
            target.checkout(books);
            double actual = target.OrderAmount;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
