namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedCourtId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "Court_CourtId", "dbo.Courts");
            RenameColumn(table: "dbo.Matches", name: "Court_CourtId", newName: "Court_CourtNumber");
            RenameIndex(table: "dbo.Matches", name: "IX_Court_CourtId", newName: "IX_Court_CourtNumber");
            DropPrimaryKey("dbo.Courts");
            AlterColumn("dbo.Courts", "CourtNumber", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Courts", "CourtNumber");
            AddForeignKey("dbo.Matches", "Court_CourtNumber", "dbo.Courts", "CourtNumber");
            DropColumn("dbo.Courts", "CourtId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courts", "CourtId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Matches", "Court_CourtNumber", "dbo.Courts");
            DropPrimaryKey("dbo.Courts");
            AlterColumn("dbo.Courts", "CourtNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Courts", "CourtId");
            RenameIndex(table: "dbo.Matches", name: "IX_Court_CourtNumber", newName: "IX_Court_CourtId");
            RenameColumn(table: "dbo.Matches", name: "Court_CourtNumber", newName: "Court_CourtId");
            AddForeignKey("dbo.Matches", "Court_CourtId", "dbo.Courts", "CourtId");
        }
    }
}
