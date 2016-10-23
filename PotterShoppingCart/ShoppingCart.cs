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
            else
            {
                int booksgroupcount = books.GroupBy(x => x.Episode).Count();
                if (booksgroupcount > 0)
                {
                    int SkipNumber = 0;
                    int MinOfAllBookGroupCount = 0;
                    int MaxOfAllBookGroupCount = 0;
                    do
                    {
                        var BooksGroup = books
                                        .GroupBy(g => new { g.Episode })
                                        .SelectMany(g => g.Skip(SkipNumber))
                                        .Where(g => g != null)
                                        .GroupBy(g => g.Episode);

                        booksgroupcount = BooksGroup.Count();

                        MinOfAllBookGroupCount = BooksGroup
                                                .Select(x => x.Count())
                                                .Min();
                        MaxOfAllBookGroupCount = BooksGroup
                                                .Select(x => x.Count())
                                                .Max();

                        SkipNumber += MinOfAllBookGroupCount;

                        this.OrderAmount += GetSubtotal(booksgroupcount, MinOfAllBookGroupCount);
                    } while (MaxOfAllBookGroupCount > MinOfAllBookGroupCount);
                }
            }                   
        }

        private double GetSubtotal(int BooksGroupCount, int NumberOfGroups)
        {
            switch (BooksGroupCount)
            {
                case 2:
                    return (100 * BooksGroupCount * 0.95) * NumberOfGroups;
                case 3:
                    return (100 * BooksGroupCount * 0.9) * NumberOfGroups;
                case 4:
                    return (100 * BooksGroupCount * 0.8) * NumberOfGroups;
                case 5:
                    return (100 * BooksGroupCount * 0.75) * NumberOfGroups;
                default:
                    return (100 * BooksGroupCount) * NumberOfGroups;
            }
        }
    }
}