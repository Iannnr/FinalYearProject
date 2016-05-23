namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDateofBirth3IndividualInts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DayOfBirth", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "MonthofBirth", c => c.String());
            AddColumn("dbo.Customers", "YearOfBirth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "YearOfBirth");
            DropColumn("dbo.Customers", "MonthofBirth");
            DropColumn("dbo.Customers", "DayOfBirth");
        }
    }
}
