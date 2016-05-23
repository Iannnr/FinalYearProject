namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DayOfBirth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DayOfBirth", c => c.String());
        }
    }
}
