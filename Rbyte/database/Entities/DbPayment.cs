namespace Rbyte.database.Entities
{
    public class DbPayment
    {
        public int PaymentId { get; set; }
        public int SubscriptionId { get; set; }
        public virtual DbSubscription Subscription { get; set; }
    }
}