using GameEndpoints.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameEndpoints.Infrastructure.Data.Map
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            ToTable("Game");

            Property(x => x.GameId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.GameName).HasMaxLength(250);
        }
    }
}
