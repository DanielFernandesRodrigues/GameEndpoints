using System;

namespace GameEndpoints.Api.Model
{
    public class LeaderbordModel
    {
        public long PlayerId { get; set; }
        public long Balance { get; set; }
        public DateTime LastUpdate { get; set; }

        public LeaderbordModel(long playerId, long balance, DateTime lastUpdate)
        {
            this.PlayerId = playerId;
            this.Balance = balance;
            this.LastUpdate = lastUpdate;
        }
    }
}