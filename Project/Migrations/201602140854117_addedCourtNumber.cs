namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCourtNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courts", "CourtNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courts", "CourtNumber");
        }
    }
}
