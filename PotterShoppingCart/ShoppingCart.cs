using System;
using System.Collections.Generic;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        public double OrderAmount;

        public ShoppingCart()
        {
        }

        public void checkout(List<HarryPotter> books)
        {
            this.OrderAmount = 100;
        }
    }
}