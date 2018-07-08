namespace PDFFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaperFormats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Height = c.Double(),
                        Width = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Documents", "PaperFormatId", c => c.Int());
            AddColumn("dbo.Groups", "PaperFormatId", c => c.Int());
            CreateIndex("dbo.Documents", "PaperFormatId");
            CreateIndex("dbo.Groups", "PaperFormatId");
            AddForeignKey("dbo.Documents", "PaperFormatId", "dbo.PaperFormats", "Id");
            AddForeignKey("dbo.Groups", "PaperFormatId", "dbo.PaperFormats", "Id");
            DropColumn("dbo.Documents", "PaperFormat");
            DropColumn("dbo.Groups", "PaperFormat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "PaperFormat", c => c.Int());
            AddColumn("dbo.Documents", "PaperFormat", c => c.Int());
            DropForeignKey("dbo.Groups", "PaperFormatId", "dbo.PaperFormats");
            DropForeignKey("dbo.Documents", "PaperFormatId", "dbo.PaperFormats");
            DropIndex("dbo.Groups", new[] { "PaperFormatId" });
            DropIndex("dbo.Documents", new[] { "PaperFormatId" });
            DropColumn("dbo.Groups", "PaperFormatId");
            DropColumn("dbo.Documents", "PaperFormatId");
            DropTable("dbo.PaperFormats");
        }
    }
}
