using System;

namespace GameEndpoints.Domain.Model
{
    public class Balance
    {
        public long BalanceId { get; private set; }
        public virtual Player Player { get; private set; }
        public long Points { get; private set; }
        public DateTime LastUpdate { get; set; }

        protected Balance() { }

        public Balance(Player player, long points)
        {
            this.Player = player;
            this.Points = points;
            this.LastUpdate = DateTime.Now;
        }

        public void UpdatePoints(long win)
        {
            this.Points += win;
            this.LastUpdate = DateTime.Now;
        }
    }
}
