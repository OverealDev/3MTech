using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Controllers;
using WebApplication2.Data;
using WebApplication2.Models;

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

            var list1 = await userController.getContextUserController().Users.ToListAsync();
            var list2 = await userController.Get();

            //Act and assert
            Enumerable.SequenceEqual(list1.OrderBy( t => t), list2.OrderBy(t => t));

        }

        [TestMethod]

        public async Task UserController_GetById_returnUser()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);
            UserController userController = new UserController(context);
            int id1 = 1;
            int id2 = 3;

            //Act
            var user1 = await userController.GetById(id1);
            var user2 = await userController.GetById(id2);

            var OkUser1 = user1 as OkObjectResult;
            var OkUser2 = user2 as OkObjectResult;

            //Assert
            Assert.IsNotNull(OkUser1);
            Assert.AreEqual(200, OkUser1.StatusCode);

            Assert.IsNull(OkUser2);

        }

        [TestMethod]

        public void UserController_GetByEmailPassword_returnUser()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);
            UserController userController = new UserController(context);
            string email1 = "tes@gmail.com";
            string password1 = "test";
            string email2 = "non";
            string password2 = "tes1t";

            //Act

            var user1 = userController.GetByEmailPassword(email1, password1);
            var user2 = userController.GetByEmailPassword(email2, password2);
            var OkUser1 = user1 as OkObjectResult;
            var OkUser2 = user2 as OkObjectResult;

            //Assert
            Assert.IsNotNull(OkUser1);
            Assert.AreEqual(200, OkUser1.StatusCode);

            Assert.IsNull(OkUser2);


        }


        [TestMethod]
        public void UserController_GetByEmail_returnUser()
        {
            //Arrange
            DbContextOptions<ItemDbContext> options = new DbContextOptions<ItemDbContext>();
            ItemDbContext context = new ItemDbContext(options);
            UserController userController = new UserController(context);
            string email1 = "tes@gmail.com";
            string email2 = "non";

            //Act

            var user1 = userController.GetByEmail(email1);
            var user2 = userController.GetByEmail(email2);
            var OkUser1 = user1 as OkObjectResult;
            var OkUser2 = user2 as OkObjectResult;

            //Assert
            Assert.IsNotNull(OkUser1);
            Assert.AreEqual(200, OkUser1.StatusCode);

            Assert.IsNull(OkUser2);


        }
    }
}
