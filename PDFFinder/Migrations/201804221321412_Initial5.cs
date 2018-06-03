namespace PDFFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "PrinterName", c => c.String(maxLength: 100));
            AddColumn("dbo.Groups", "Duplex", c => c.Boolean());
            AddColumn("dbo.Groups", "PaperFormat", c => c.Int());
            DropColumn("dbo.Documents", "PrinterName");
            DropColumn("dbo.Documents", "Duplex");
            DropColumn("dbo.Documents", "PaperFormat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "PaperFormat", c => c.Int());
            AddColumn("dbo.Documents", "Duplex", c => c.Boolean());
            AddColumn("dbo.Documents", "PrinterName", c => c.String(maxLength: 100));
            DropColumn("dbo.Groups", "PaperFormat");
            DropColumn("dbo.Groups", "Duplex");
            DropColumn("dbo.Groups", "PrinterName");
        }
    }
}
