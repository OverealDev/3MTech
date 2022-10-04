using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.IO;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public Item[] content;

        public ItemController()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "\\expenses.txt");

            StreamReader sr = new(@"C:\Users\Maxime\Desktop\S5\software_engineering_I_II\3MTech\reactproject1\WebApplication2\Controllers\expenses.txt");

            var tmp = sr.ReadToEnd();

            sr.Close();

            content = JsonConvert.DeserializeObject<Item[]>(tmp);
            
            
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return content;
        }
        /*
        [HttpPost]
        public IActionResult Create(Item item)
        {

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

        }*/
    }
}
