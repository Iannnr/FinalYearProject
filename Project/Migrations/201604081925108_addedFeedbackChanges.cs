namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFeedbackChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "AdditionalInformation", c => c.String());
            AddColumn("dbo.Customers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Matches", "AdditionalInformation");
        }
    }
}
