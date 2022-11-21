using WebApplication2.Controllers;
using WebApplication2.Models;



namespace _3MTechTests
{
    [TestClass]
    public class LINQtests
    {
        [TestMethod]
        public void LINQtestsMethod() {


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

            LINQRequests requests = new LINQRequests();
            IQueryable<PriceAndType> results = requests.LINQFunction(item1, item2, item3, item4);

            bool flag = true;
            int compter = -1;
            List<float> TrueResult = new List<float>();
            TrueResult.Add(10 / 3);
            TrueResult.Add(6);

            foreach (PriceAndType tests in results)
            {

                compter = compter + 1;
                if ((tests.Average) != TrueResult[compter])
                {
                    flag = false;
                }

            }

            Assert.IsTrue(flag);


        }
    }
}