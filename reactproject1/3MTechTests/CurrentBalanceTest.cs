using WebApplication2.Controllers;
using WebApplication2.Models;



namespace _3MTechTests
{
    [TestClass]
    public class CurrentBalanceTest
    {
        [TestMethod]
        public void CurrentBalance_test()
        {

            DateTime DT2 = new DateTime(2021, 06, 14, 0, 0, 0);
            Item item1 = new Item(2, "test2", 5, DT2, WebApplication2.Models.Type.Food, 1);
            Item item2 = new Item(2, "test2", 5, DT2, WebApplication2.Models.Type.Food, 1);
            Item item3 = new Item(2, "test2", 5, DT2, WebApplication2.Models.Type.Food, 1);
            Item item4 = new Item(2, "test2", 5, DT2, WebApplication2.Models.Type.Food, 1);

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