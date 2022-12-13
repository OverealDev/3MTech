using Microsoft.EntityFrameworkCore;
using WebApplication2.Controllers;
using WebApplication2.Data;


namespace _3MTechTests
{
    [TestClass]
    public class ItemControllerTests
    {
        [TestMethod]
        public void ItemController_ItemController_CreateWithContext()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);

            //Act
            ItemController itemController = new ItemController(context);

            //Assert
            Assert.AreEqual(itemController.getContextItemController(), context);

        }
    }
}