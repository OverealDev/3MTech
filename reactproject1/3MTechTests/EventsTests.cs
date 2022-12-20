
using WebApplication2.Events;
namespace _3MTechTests
{
    [TestClass]
    public class EventsTests
    {
        [TestMethod]
        public void TestEvents_CheckingIfOverpriced()
        {
            // Arrange
            decimal amountAbove = 100_000_000_000;
            decimal amountBelow = 10;
            Events events = new Events();


            events.checkingIfOverpriced(amountAbove);


           
        }
    }
}