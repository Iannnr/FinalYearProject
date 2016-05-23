namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRBGValues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coaches", "CoachRed", c => c.Int(nullable: false));
            AddColumn("dbo.Coaches", "CoachGreen", c => c.Int(nullable: false));
            AddColumn("dbo.Coaches", "CoachBlue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coaches", "CoachBlue");
            DropColumn("dbo.Coaches", "CoachGreen");
            DropColumn("dbo.Coaches", "CoachRed");
        }
    }
}
