using WebApplication2.Controllers;
using WebApplication2.Models;



namespace _3MTechTests
{
    [TestClass]
    public class LINQtests
    {
        [TestMethod]
        public void LINQtestsMethod() {


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

            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);


            LINQRequests requests = new LINQRequests();
            Lazy<IEnumerable<PriceAndType>> results = requests.LINQFunction<IEnumerable<PriceAndType>>(items);
            IEnumerable<PriceAndType> results_ = (IEnumerable<PriceAndType>)LazyInitializer.EnsureInitialized(ref results);



            bool flag = true;
            int compter = -1;
            List<float> TrueResult = new List<float>();
            TrueResult.Add(10 / 3);
            TrueResult.Add(6);

            if (results != null)
            {
                foreach (PriceAndType tests in results_)
                {

                    compter = compter + 1;
                    if ((tests.Average) != TrueResult[compter])
                    {
                        flag = false;
                    }

                }
            }
            

            Assert.IsTrue(flag);


        }
    }
}