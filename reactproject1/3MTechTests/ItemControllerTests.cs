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

        [TestMethod]

        public async Task ItemController_Get_returnContextUsers()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);
            ItemController itemController = new ItemController(context);

            var list1 = await itemController.getContextItemController().Items.ToListAsync();
            var list2 = await itemController.Get();

            //Act and assert
            Enumerable.SequenceEqual(list1.OrderBy(t => t), list2.OrderBy(t => t));

        }
    }
}