namespace PDFFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Documents", "PrinterName");
            DropColumn("dbo.Groups", "PrinterName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "PrinterName", c => c.String(maxLength: 100));
            AddColumn("dbo.Documents", "PrinterName", c => c.String(maxLength: 100));
        }
    }
}
