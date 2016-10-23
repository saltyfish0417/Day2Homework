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

        /// <summary>
        /// 結帳，取得訂單總金額
        /// </summary>
        /// <param name="books"></param>
        public void checkout(List<HarryPotter> books)
        {       
            int booksgroupcount = books.GroupBy(x => x.Episode).Count();    //依集別分組後，取組數
            if (booksgroupcount > 0)
            {
                int SkipNumber = 0;
                int MinOfAllBookGroupCount = 0; //依集別分組後，各組別中之最少購買數量
                int MaxOfAllBookGroupCount = 0; //依集別分組後，各組別中之最大購買數量
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

        /// <summary>
        /// 取得小計金額
        /// </summary>
        /// <param name="BooksGroupCount"></param>
        /// <param name="NumberOfGroups"></param>
        /// <returns></returns>
        private double GetSubtotal(int BooksGroupCount, int NumberOfGroups)
        {
            switch (BooksGroupCount)
            {
                case 2:
                    //購買NumberOfGroups組[2本集別不同的書]
                    return (100 * BooksGroupCount * 0.95) * NumberOfGroups;
                case 3:
                    //購買NumberOfGroups組[3本集別不同的書]
                    return (100 * BooksGroupCount * 0.9) * NumberOfGroups;
                case 4:
                    //購買NumberOfGroups組[4本集別不同的書]
                    return (100 * BooksGroupCount * 0.8) * NumberOfGroups;
                case 5:
                    //購買NumberOfGroups組[5本集別不同的書]
                    return (100 * BooksGroupCount * 0.75) * NumberOfGroups;
                default:
                    //同一集別的書購買NumberOfGroups本
                    return (100 * BooksGroupCount) * NumberOfGroups;
            }
        }
    }
}