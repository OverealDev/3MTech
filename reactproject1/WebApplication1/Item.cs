using System.Collections;

namespace Classes
{
    public class Item 
    {

        public string Name { get; set; }
        public int Id { get; set; }
         public int Price { get; set; }


        public void AddItem(string name, int id, int price)
        {
            this.Name = name;
            this.Id = id;
            this.Price = price;
            

        }
         
    }
}
