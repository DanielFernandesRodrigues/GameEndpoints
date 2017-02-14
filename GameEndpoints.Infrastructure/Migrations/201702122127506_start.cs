namespace GameEndpoints.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balance",
                c => new
                    {
                        BalanceId = c.Long(nullable: false, identity: true),
                        Points = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.BalanceId)
                .ForeignKey("dbo.Player", t => t.BalanceId)
                .Index(t => t.BalanceId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Long(nullable: false, identity: true),
                        PlayerName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.GameResult",
                c => new
                    {
                        GameResultId = c.Long(nullable: false, identity: true),
                        Win = c.Long(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        Game_GameId = c.Long(nullable: false),
                        Player_PlayerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.GameResultId)
                .ForeignKey("dbo.Game", t => t.Game_GameId, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.Player_PlayerId, cascadeDelete: true)
                .Index(t => t.Game_GameId)
                .Index(t => t.Player_PlayerId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Long(nullable: false, identity: true),
                        GameName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameResult", "Player_PlayerId", "dbo.Player");
            DropForeignKey("dbo.GameResult", "Game_GameId", "dbo.Game");
            DropForeignKey("dbo.Balance", "BalanceId", "dbo.Player");
            DropIndex("dbo.GameResult", new[] { "Player_PlayerId" });
            DropIndex("dbo.GameResult", new[] { "Game_GameId" });
            DropIndex("dbo.Balance", new[] { "BalanceId" });
            DropTable("dbo.Game");
            DropTable("dbo.GameResult");
            DropTable("dbo.Player");
            DropTable("dbo.Balance");
        }
    }
}
