namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeddatetime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Matches", "MatchTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "MatchTime", c => c.DateTime(nullable: false));
        }
    }
}
