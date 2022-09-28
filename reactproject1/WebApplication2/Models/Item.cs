

using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Item
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

        


        public void AddItem(int id, string title, float amount, DateTime date)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Date = date;

        }

    }

    public enum Type
    {
        Books, Cleaning_stuff, Food
    }
}