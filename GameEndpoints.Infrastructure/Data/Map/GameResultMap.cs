using GameEndpoints.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameEndpoints.Infrastructure.Data.Map
{
    public class GameResultMap : EntityTypeConfiguration<GameResult>
    {
        public GameResultMap()
        {
            ToTable("GameResult");

            Property(x => x.GameResultId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
