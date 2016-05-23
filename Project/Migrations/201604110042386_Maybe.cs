namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maybe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DayOfBirth", c => c.String());
            AlterColumn("dbo.Customers", "YearOfBirth", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "YearOfBirth", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "DayOfBirth", c => c.Int(nullable: false));
        }
    }
}
