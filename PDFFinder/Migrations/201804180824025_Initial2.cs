namespace PDFFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "Duplex", c => c.Boolean());
            AlterColumn("dbo.Documents", "PaperFormat", c => c.Int());
            AlterColumn("dbo.Documents", "Views", c => c.Int());
            AlterColumn("dbo.Documents", "Prints", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "Prints", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "Views", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "PaperFormat", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "Duplex", c => c.Boolean(nullable: false));
        }
    }
}
