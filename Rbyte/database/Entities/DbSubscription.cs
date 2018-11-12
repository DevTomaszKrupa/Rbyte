using System.Collections.Generic;

namespace Rbyte.database.Entities {
    public class DbSubscription {
        public DbSubscription()
        {
            Payments = new HashSet<DbPayment>();
        }
        
        public int SubscriptionId { get; set; }
        public int Cost { get; set; }

        public ICollection<DbPayment> Payments { get; set; }
    }
}