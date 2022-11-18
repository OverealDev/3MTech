namespace WebApplication2.Events
{
    public class OverpricedEventArgs : EventArgs
    {
        public decimal OverpricedAmount { get; set; }

        public OverpricedEventArgs(decimal overpricedAmount)
        {
            OverpricedAmount = overpricedAmount;
        }
    }
}
