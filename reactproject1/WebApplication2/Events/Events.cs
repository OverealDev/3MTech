namespace WebApplication2.Events
{
    public class Events
    {
        public delegate void OverpricedEventHandler(object sender, EventArgs e);

        public event OverpricedEventHandler Overpriced;

        public void CheckingIfOverpriced(decimal amount)
        {
            if(amount >= 100_000_000_000)
            {
                Overpriced(this, new OverpricedEventArgs(amount));
            }
        }

    }
}
