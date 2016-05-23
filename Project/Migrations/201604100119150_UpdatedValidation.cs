namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MobileNumber", c => c.String());
            AddColumn("dbo.Customers", "LandlineNumber", c => c.String());
            DropColumn("dbo.Customers", "primaryContact");
            DropColumn("dbo.Customers", "secondaryContact");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "secondaryContact", c => c.String());
            AddColumn("dbo.Customers", "primaryContact", c => c.String());
            DropColumn("dbo.Customers", "LandlineNumber");
            DropColumn("dbo.Customers", "MobileNumber");
        }
    }
}
