﻿using WebApplication2.Controllers;
using WebApplication2.Models;



namespace _3MTechTests
{
    [TestClass]
    public class CurrentBalanceTest
    {
        [TestMethod]
        public void CurrentBalance_test()
        {


            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();

            item1.Amount = 3;
            item1.Type = WebApplication2.Models.Type.Books;

            item2.Amount = 5;
            item2.Type = WebApplication2.Models.Type.Books;

            item3.Amount = 2;
            item3.Type = WebApplication2.Models.Type.Books;

            item4.Amount = 6;
            item4.Type = WebApplication2.Models.Type.Cleaning_stuff;

            List<Item> list = new List<Item> { item1, item2, item3, item4 };


            Current_balance balance = new Current_balance("Euro", list);
            Assert.AreEqual(balance.totalAmount, 16);



        }
    }
}