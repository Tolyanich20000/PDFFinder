namespace PDFFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "PrinterName", c => c.String(maxLength: 100));
            AddColumn("dbo.Documents", "Duplex", c => c.Boolean());
            AddColumn("dbo.Documents", "PaperFormat", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "PaperFormat");
            DropColumn("dbo.Documents", "Duplex");
            DropColumn("dbo.Documents", "PrinterName");
        }
    }
}
