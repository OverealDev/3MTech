using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
        public class HomeController : Controller
        {
        
        
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
     

            [HttpPost]
            public ActionResult Index(Models.Login objuserlogin)
            {
                var display = Userloginvalues("User1","passwrd").Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword).FirstOrDefault();
                if (display != null)
                {
                    ViewBag.Status = "Logging in";
                }

                else
                {
                    ViewBag.Status = "INCORRECT Username or Password";
                }
                return View(objuserlogin);
            }
            public List<Models.Login> Userloginvalues(String UserName_, String UserPassword_)
            {
                List<Models.Login> objModel = new List<Models.Login>();
                objModel.Add(new Models.Login { UserName = UserName_, UserPassword = UserPassword_ });
           
                return objModel;
            }
        }
       
    
}
