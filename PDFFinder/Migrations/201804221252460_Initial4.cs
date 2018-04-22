namespace PDFFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Documents", "LastViewDateTime", c => c.DateTime());
            AddColumn("dbo.Documents", "LastPrintDateTime", c => c.DateTime());
            AddColumn("dbo.Documents", "GroupId", c => c.Int());
            AlterColumn("dbo.Documents", "ReportName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Documents", "PrinterName", c => c.String(maxLength: 100));
            CreateIndex("dbo.Documents", "GroupId");
            AddForeignKey("dbo.Documents", "GroupId", "dbo.Groups", "Id");
            DropColumn("dbo.Documents", "GroupName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "GroupName", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Documents", "GroupId", "dbo.Groups");
            DropIndex("dbo.Documents", new[] { "GroupId" });
            AlterColumn("dbo.Documents", "PrinterName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Documents", "ReportName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Documents", "GroupId");
            DropColumn("dbo.Documents", "LastPrintDateTime");
            DropColumn("dbo.Documents", "LastViewDateTime");
            DropTable("dbo.Groups");
        }
    }
}
