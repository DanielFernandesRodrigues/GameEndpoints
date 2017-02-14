using GameEndpoints.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GameEndpoints.Infrastructure.Data.Map
{
    public class BalanceMap : EntityTypeConfiguration<Balance>
    {
        public BalanceMap()
        {
            ToTable("Balance");

            Property(x => x.BalanceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
