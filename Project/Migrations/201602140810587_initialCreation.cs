namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        CoachID = c.Int(nullable: false, identity: true),
                        CoachColorHexValue = c.String(),
                        player_playerId = c.Int(),
                    })
                .PrimaryKey(t => t.CoachID)
                .ForeignKey("dbo.Players", t => t.player_playerId)
                .Index(t => t.player_playerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        playerId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Court_CourtId = c.Int(),
                    })
                .PrimaryKey(t => t.playerId)
                .ForeignKey("dbo.Courts", t => t.Court_CourtId)
                .Index(t => t.Court_CourtId);
            
            CreateTable(
                "dbo.Courts",
                c => new
                    {
                        CourtId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CourtId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchID = c.Int(nullable: false, identity: true),
                        MatchTime = c.DateTime(nullable: false),
                        Court_CourtId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchID)
                .ForeignKey("dbo.Courts", t => t.Court_CourtId)
                .Index(t => t.Court_CourtId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        primaryContact = c.String(),
                        secondaryContact = c.String(),
                        player_playerId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Players", t => t.player_playerId)
                .Index(t => t.player_playerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "player_playerId", "dbo.Players");
            DropForeignKey("dbo.Players", "Court_CourtId", "dbo.Courts");
            DropForeignKey("dbo.Matches", "Court_CourtId", "dbo.Courts");
            DropForeignKey("dbo.Coaches", "player_playerId", "dbo.Players");
            DropIndex("dbo.Customers", new[] { "player_playerId" });
            DropIndex("dbo.Matches", new[] { "Court_CourtId" });
            DropIndex("dbo.Players", new[] { "Court_CourtId" });
            DropIndex("dbo.Coaches", new[] { "player_playerId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Matches");
            DropTable("dbo.Courts");
            DropTable("dbo.Players");
            DropTable("dbo.Coaches");
        }
    }
}
