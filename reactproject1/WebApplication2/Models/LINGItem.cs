using System;

namespace WebApplication2.Models;

internal class Program
{
    static void Main(string[] args)
    {

        DateTime DT2 = new DateTime(2021, 06, 14, 0, 0, 0);

        Item item1 = new Item(2, "test2", 5, DT2, WebApplication2.Models.Type.Food, 1);
        Item item2 = new Item(2, "test2", 5, DT2, WebApplication2.Models.Type.Food, 1);
        Item item3 = new Item(2, "test2", 5, DT2, WebApplication2.Models.Type.Food, 1);

        item1.Amount = 3;
        item1.Type = Type.Books;

        item2.Amount = 5;
        item2.Type = Type.Books;

        item3.Amount = 6;
        item3.Type = Type.Cleaning_stuff;


        List<Item> itemList = new List<Item>{item1, item2, item3};
        Current_balance current_balance = new Current_balance("Euro", itemList);
        Console.WriteLine(current_balance.totalAmount);


        var PricePerType = from item in itemList
                           group item by new
                           {
                               item.Type
                           } into rows
                           select new
                           {
                               Average = rows.Average(p => p.Amount),
                               rows.Key.Type
                           };


        foreach(var test in PricePerType)
        {
            Console.WriteLine(test + " ");

        }


    }
}