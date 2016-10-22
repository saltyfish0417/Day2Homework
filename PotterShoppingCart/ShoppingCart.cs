using System;
using System.Collections.Generic;
using System.Linq;

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
            if (books.Count == 1)
            {
                this.OrderAmount = 100;
            }
            else if (books.Count == 2)
            {
                if (books[0].Episode.Equals(books[1].Episode))
                {
                    this.OrderAmount = 100 * 2;
                }
                else
                {
                    this.OrderAmount = 100 * 2 * 0.95;
                    
                }
            }
            else if (books.Count == 3)
            {
                int booksgroupcout = books.GroupBy(x => x.Episode).Count();
                switch (booksgroupcout)
                {
                    case 1:
                        this.OrderAmount = 100 * 3;
                        break;
                    case 2:
                        this.OrderAmount = (100 * 2 * 0.95) + 100;
                        break;
                    case 3:
                        this.OrderAmount = 100 * 3 * 0.90;
                        break;
                }
            }         
        }
    }
}