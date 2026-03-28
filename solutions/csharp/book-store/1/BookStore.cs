using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Transactions;

public static class BookStore
{
    private static readonly Dictionary<int, decimal> discounts = new()
    {
        { 0, 0.00m },
        { 1, 0.00m },
        { 2, 0.05m },
        { 3, 0.10m },
        { 4, 0.20m },
        { 5, 0.25m }
    };

    public static decimal Total(IEnumerable<int> books)
    {
        decimal bookPrice = 8m;
        if (books.Count() == 1) return bookPrice;

        var bookList = books.Count() % 2 != 0 ? books.Reverse() : books;

        decimal total = 0m;

        List<List<int>> bookGroups = new List<List<int>>() { new List<int>() };

        foreach(int book in bookList)
        {
            foreach(List<int> group in bookGroups)
            {
                if (group.Contains(book))
                {
                    if (bookGroups.Count() > bookGroups.IndexOf(group) + 1) continue;
                    else
                    {
                        bookGroups.Add(new List<int> { book });
                        break;
                    }
                }
                else
                {
                    var bookGroupsCopy = bookGroups.Select(g => new List<int>(g)).ToList();
                    decimal currentTotalDiscount = bookGroupsCopy.Sum(g => discounts[g.Count()]);
                    int groupIndex = 0;


                    // Calculate which group returns the best discount

                    for (int i = 0; i < bookGroupsCopy.Count(); i++)
                    {
                        var currentGroup = bookGroupsCopy[i];

                        if (!currentGroup.Contains(book)) currentGroup.Add(book);
                        else continue;

                        decimal discountIfBookInGroup = bookGroupsCopy.Sum(g => discounts[g.Count()]);

                        if (discountIfBookInGroup > currentTotalDiscount)
                        {
                            currentTotalDiscount = discountIfBookInGroup;
                            groupIndex = i;
                        }
                        else if(bookGroupsCopy.Count() > 1 && discountIfBookInGroup == currentTotalDiscount && currentGroup.Count() == bookGroupsCopy[i - 1].Count())
                        {
                            if (books.Count() % 2 != 0) break;

                            currentTotalDiscount = discountIfBookInGroup;
                            groupIndex = i;
                        }

                        currentGroup.Remove(book);
                    }

                    bookGroups[groupIndex].Add(book);
                    break;
                }
            }
        }

        // Calculate cost
        foreach(var group in bookGroups)
        {
            int numBooks = group.Count();

            if(numBooks > 1)
            {
                decimal priceWODiscount = numBooks * bookPrice;
                total += priceWODiscount - (discounts[numBooks] * priceWODiscount); 
            }
            else total += numBooks * bookPrice;
        }

        return total;
    }
}






// book 5 is just added to group 0 because of this condition
//if (groups.Count() > i + 1 &&
//    groups[i + 1].Count() < groups[i].Count() &&
//    !groups[i + 1].Contains(book)) 
//{
//    if (discounts.Keys.Contains(groups[i].Count()))
//    {
//        // I think this isn't considering more than 2 groups
//        decimal a = discounts[groups[i].Count() + 1] + (groups[i + 1].Count() > 1 ? discounts[groups[i + 1].Count()] : 0m);
//        decimal b = discounts[groups[i].Count()] + discounts[groups[i + 1].Count() + 1];

//        if (a > b)
//        {
//            groups[i].Add(book);
//            break;
//        }
//        else continue;
//    }

//    continue;
//} 
//else
//{
//    groups[i].Add(book);
//    break;
//}



// -----

//foreach(int book in books)
//{
//    for (int i = 0; i < groups.Count(); i++)
//    {
//        List<int> currentGroup = groups[i];
//        //List<int>? adjacentGroup = groups.Count() > 1 ? groups[i + 1] : null;

//        // This if else block does the grouping -- Grouping is based on greatest discount
//        // Greatest discount is achieved by dividing books into group correctly
//        // By creating as many combinations of unique books as possible that add up to the greatest discount
//        if (currentGroup.Contains(book))
//        {
//            //if (groups.Count() > i + 1 && !groups[i + 1].Contains(book))
//            if (groups.Count() > i + 1) continue;
//            else
//            {
//                groups.Add(new List<int>() { book });
//                break;
//            }
//        }
//        else
//        {
//            decimal currentTotalDiscount = groups.Sum(g => discounts[g.Count()]);
//            decimal comparisonTotalDiscount = 0m;
//            int groupIndex = 0;

//            //Calculate best discount
//            //foreach (var group in groups) comparisonTotalDiscount += group.Count() > 1 ? discounts[group.Count()] : 0;

//            foreach(var group in groups)
//            {
//                if (!group.Contains(book)) group.Add(book);
//                else continue;

//                decimal currentDiscount = groups.Sum(g => discounts[g.Count()]);

//                comparisonTotalDiscount = Math.Max(currentDiscount, comparisonTotalDiscount);
//                groupIndex = groups.IndexOf(group);

//                groups[groupIndex].Remove(book);
//            }

//            groups[groupIndex].Add(book);
//        }
//    }
//}