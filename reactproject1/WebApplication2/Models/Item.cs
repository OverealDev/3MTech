

using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Item : IComparable<Item>
    {
        //[Required]
        public int Id { get; set; }
        //[Required]
        public string Title { get; set; }
        //[Required]
        public float Amount { get; set; }
        //[Required]
        public DateTime Date { get; set; }
        //[Required]
        public Type Type { get; set; }

        public int UserId { get; set; }

        

        public Item(int id, string title, float amount, DateTime date, Type type, int userId)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Date = date;
            Type = type;
            UserId = userId;
        }


        public int CompareTo(Item other)
        {
            if (other.Id == this.Id && other.Title == this.Title && other.Amount == this.Amount && other.UserId == this.UserId && this.Date == other.Date)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }


    public enum Type
    {
        Books, Cleaning_stuff, Food
    }

    public class PriceAndType
    {
        public float Average { get; set; }
        public Type PriceType { get; set; }
    }


    public class LINQRequests
    {

        public Lazy<T> LINQFunction<T>(List<Item> itemList)
        {

   
            
            Current_balance current_balance = new Current_balance("Euro", itemList);



             var PricePerType_ = from item in itemList
                                group item by new
                                {
                                    item.Type
                                } into rows
                                select new
                                {
                                    Average = rows.Average(p => p.Amount),
                                    PriceType = rows.Key.Type
                                };



            return (Lazy<T>)PricePerType_;

        }
    }

}