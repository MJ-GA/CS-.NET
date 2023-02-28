namespace Lab4.Models
{
    public class Subscription
    {

        public int ClientId { get; set; }

        public string BrokerageId { get; set; }

        public Client Client { get; set; }

        public Brokerage Brokerage { get; set; }


    }
}