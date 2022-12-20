using System.Runtime.ConstrainedExecution;

namespace WebApplication2.Events
{
    public class Events
    {
        public delegate void OverpricedEventHandler(object sender, EventArgs e);

        public event OverpricedEventHandler Overpriced;

        public void checkingIfOverpriced(decimal amount)
        {
            if(amount >= 100_000_000_000)
            {
                checkingOverpriced(new OverpricedEventArgs(amount));
            }
        }
        protected virtual void checkingOverpriced(EventArgs e)
        {
            Overpriced?.Invoke(this, e);
        }

    }
}
