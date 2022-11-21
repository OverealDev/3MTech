

using System.ComponentModel.DataAnnotations;
using static WebApplication2.Models.newItem;

namespace WebApplication2.Models

{
    public interface Add
    {
        List<InjectItem> Itemlist();
    }


    public class newItem : Add
    {

        public List<InjectItem> Itemlist()
        {
            List<InjectItem> ListItems = new List<InjectItem>();
            //take items from db

            return ListItems;
        }
        public class creator
        {
            public newItem newitem;
            public creator(newItem newitem)
            {
                this.newitem = newitem;
            }
            public List<InjectItem> GetItems()
            {
                return newitem.Itemlist();
            }
        }

        public class InjectItem
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public string Title { get; set; }
            [Required]
            public float Amount { get; set; }
            [Required]
            public DateTime Date { get; set; }
            [Required]
            public Type Type { get; set; }





        }

        public enum Type
        {
            Books, Cleaning_stuff, Food
        }
    }
}