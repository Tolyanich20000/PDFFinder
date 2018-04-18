namespace PDFFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        ReportName = c.String(nullable: false, maxLength: 50),
                        PrinterName = c.String(maxLength: 50),
                        Duplex = c.Boolean(nullable: false),
                        PaperFormat = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        Prints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documents");
        }
    }
}
