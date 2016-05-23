namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedMatchLayout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "CoachInMatch_CoachID", c => c.Int());
            CreateIndex("dbo.Matches", "CoachInMatch_CoachID");
            AddForeignKey("dbo.Matches", "CoachInMatch_CoachID", "dbo.Coaches", "CoachID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "CoachInMatch_CoachID", "dbo.Coaches");
            DropIndex("dbo.Matches", new[] { "CoachInMatch_CoachID" });
            DropColumn("dbo.Matches", "CoachInMatch_CoachID");
        }
    }
}
