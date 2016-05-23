namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMatchTimeVariables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "dayOfWeek", c => c.String());
            AddColumn("dbo.Matches", "dateOfMonth", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "monthOfYear", c => c.String());
            AddColumn("dbo.Matches", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "TimeOfDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "TimeOfDay");
            DropColumn("dbo.Matches", "Year");
            DropColumn("dbo.Matches", "monthOfYear");
            DropColumn("dbo.Matches", "dateOfMonth");
            DropColumn("dbo.Matches", "dayOfWeek");
        }
    }
}
