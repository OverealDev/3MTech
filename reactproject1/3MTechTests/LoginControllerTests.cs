using WebApplication2.Controllers;
using WebApplication2.Models;



namespace _3MTechTests
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public void TestLoginUserValues()
        {
            //Arrange
            String UserName_ = "test1";
            String UserPassword_ = "pwd1";

            //Act
            List<WebApplication2.Models.Login> objModel1 = new HomeController().Userloginvalues(UserName_, UserPassword_);


            //Assert
            List<WebApplication2.Models.Login> expected = new List<WebApplication2.Models.Login> {
                new WebApplication2.Models.Login
                {
                    UserName = "test1", UserPassword = "pwd1",
                }
                };
            Assert.AreEqual(expected, objModel1);






        }
    }
}