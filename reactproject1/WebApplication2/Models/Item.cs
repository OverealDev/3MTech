

namespace WebApplication2.Models
{
    public class Item
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }


        public void AddItem(int id, string title, float amount, DateTime date)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Date = date;

        }

    }
}