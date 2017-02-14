
using GameEndpoints.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace GameEndpoints.Infrastructure.Data.Map
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable("Player");

            Property(x => x.PlayerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.PlayerName).HasMaxLength(250);
        }
    }
}
