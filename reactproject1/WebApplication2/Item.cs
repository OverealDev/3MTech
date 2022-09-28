using System.Collections;

namespace Classes
{
    public class Item
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }


        public void AddItem(int id, string title, float amount, DateTime date)
        {
            this.Id = id;
            this.Title = title;
            this.Amount = amount;
            this.Date = date; 

        }

    }
}