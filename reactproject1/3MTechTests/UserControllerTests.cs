using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Controllers;
using WebApplication2.Data;

namespace _3MTechTests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void UserController_UserController_CreateWithContext()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);

            //Act
            UserController userController = new UserController(context);

            //Assert
            Assert.AreEqual(userController.getContextUserController(), context);

        }

        [TestMethod]
        public async Task UserController_Get_returnContextUsers()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);
            UserController userController = new UserController(context);

            //Act and assert
            Assert.AreEqual(await userController.Get(),await userController.getContextUserController().Users.ToListAsync());


        }


    }
}
