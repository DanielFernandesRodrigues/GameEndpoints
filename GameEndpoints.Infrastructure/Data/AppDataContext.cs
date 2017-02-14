using GameEndpoints.Domain.Model;
using GameEndpoints.Infrastructure.Data.Map;
using System.Data.Entity;

namespace GameEndpoints.Infrastructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("ConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GameResultMap());
            modelBuilder.Configurations.Add(new BalanceMap());
            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new PlayerMap());

            modelBuilder.Entity<GameResult>()
                .HasRequired(s => s.Player).WithMany(p => p.GameResults);

            modelBuilder.Entity<GameResult>()
                .HasRequired(s => s.Game);

            modelBuilder.Entity<Balance>()
                .HasRequired(s => s.Player);
        }
    }
}
