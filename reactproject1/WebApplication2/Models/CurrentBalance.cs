namespace WebApplication2.Models;



public class Current_balance {
    public float totalAmount { get; set; }
    public String currency { get; set; } //Dollar, Euro, ...
    public float amountAverage { get; set; }

    public Current_balance(String currency_, List<Item> itemList)
    {
        this.currency = currency_;

        foreach (Item item in itemList) {

            this.totalAmount = this.totalAmount + item.Amount;
        }

    }

}
   