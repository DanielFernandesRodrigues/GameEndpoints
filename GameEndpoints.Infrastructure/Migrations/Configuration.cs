namespace GameEndpoints.Infrastructure.Migrations
{
    using GameEndpoints.Common.Validations;
    using GameEndpoints.Domain.Model;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GameEndpoints.Infrastructure.Data.AppDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GameEndpoints.Infrastructure.Data.AppDataContext context)
        {
            context.Players.AddOrUpdate(
                p => p.PlayerName,
                new Player { PlayerId = 1, PlayerName = "Guns and Roses", Email = "paradisecity@guns.com", Password = PasswordAssertionConcern.Encrypt("girlsarepretty") },
                new Player { PlayerId = 2, PlayerName = "Foo Fighters", Email = "bestofyou@foo.com", Password = PasswordAssertionConcern.Encrypt("imanewdayrising") },
                new Player { PlayerId = 3, PlayerName = "AC/DC", Email = "shoottothrill@acdc.com", Password = PasswordAssertionConcern.Encrypt("pullthetrigger") },
                new Player { PlayerId = 4, PlayerName = "Iron Maiden", Email = "runtothehills@im.com", Password = PasswordAssertionConcern.Encrypt("runforyourlives") },
                new Player { PlayerId = 5, PlayerName = "Raul Seixas", Email = "metamorfose@rs.com", Password = PasswordAssertionConcern.Encrypt("ambulante") }
                );

            context.Games.AddOrUpdate(
                p => p.GameName,
                new Game { GameId = 1, GameName = "Appetite for Destruction" },
                new Game { GameId = 2, GameName = "In Your Honor" },
                new Game { GameId = 3, GameName = "Back in Black" },
                new Game { GameId = 4, GameName = "The Number of the Beast" },
                new Game { GameId = 5, GameName = "Krig-ha, Bandolo!" }
                );

            base.Seed(context);
        }
    }
}
