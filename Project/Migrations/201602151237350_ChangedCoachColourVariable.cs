namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCoachColourVariable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coaches", "CoachColor", c => c.String());
            DropColumn("dbo.Coaches", "CoachColorHexValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coaches", "CoachColorHexValue", c => c.String());
            DropColumn("dbo.Coaches", "CoachColor");
        }
    }
}
