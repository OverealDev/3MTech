using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.Controllers;
using WebApplication2.Data;
using WebApplication2.Models;

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

        [TestMethod]
        public async Task ItemController_GetById_returnContextUsers()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);
            ItemController itemController = new ItemController(context);

            int id1 = 1;
            int id2 = 3;

            //Act
            var item1 = await itemController.GetById(id1);
            var item2 = await itemController.GetById(id2);

            var OkItem1 = item1 as OkObjectResult;
            var OkItem2 = item2 as OkObjectResult;

            //Assert
            Assert.IsNotNull(OkItem1);
            Assert.AreEqual(200, OkItem1.StatusCode);

            Assert.IsNull(OkItem2);
        }

        [TestMethod]

        public async Task ItemController_GetByUserId_returnItem()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);
            ItemController itemController = new ItemController(context);
            int userid1 = 11;
            int userid2 = 1;

            var items2Real = new List<object>();

            
            
            DateTime DT2 = new DateTime(2021, 06, 14, 0, 0, 0);
            Item items2Real1 = new Item(2, "test2", 5, DT2, WebApplication2.Models.Type.Food, 1);
            items2Real.Add(items2Real1);

            //Act
            var items1 = itemController.GetByUserId(userid1);
            var items2 = itemController.GetByUserId(userid2);
            


   
            //Assert
            Assert.IsTrue(items1.Count() == 0);

            Enumerable.SequenceEqual(items2.OrderBy(t => t), items2Real.OrderBy(t => t));

        }
    }
}