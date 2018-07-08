namespace PDFFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PaperFormats", "Height");
            DropColumn("dbo.PaperFormats", "Width");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaperFormats", "Width", c => c.Double());
            AddColumn("dbo.PaperFormats", "Height", c => c.Double());
        }
    }
}
