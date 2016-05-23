namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreationaddedplayerstomatch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "Court_CourtId", "dbo.Courts");
            DropIndex("dbo.Players", new[] { "Court_CourtId" });
            AddColumn("dbo.Players", "Match_MatchID", c => c.Int());
            CreateIndex("dbo.Players", "Match_MatchID");
            AddForeignKey("dbo.Players", "Match_MatchID", "dbo.Matches", "MatchID");
            DropColumn("dbo.Players", "Court_CourtId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Court_CourtId", c => c.Int());
            DropForeignKey("dbo.Players", "Match_MatchID", "dbo.Matches");
            DropIndex("dbo.Players", new[] { "Match_MatchID" });
            DropColumn("dbo.Players", "Match_MatchID");
            CreateIndex("dbo.Players", "Court_CourtId");
            AddForeignKey("dbo.Players", "Court_CourtId", "dbo.Courts", "CourtId");
        }
    }
}
