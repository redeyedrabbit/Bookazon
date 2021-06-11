namespace Bookazon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "PublisherId", "dbo.Publisher");
            DropIndex("dbo.Product", new[] { "PublisherId" });
            CreateTable(
                "dbo.PublisherProduct",
                c => new
                    {
                        Publisher_PublisherId = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publisher_PublisherId, t.Product_Id })
                .ForeignKey("dbo.Publisher", t => t.Publisher_PublisherId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Publisher_PublisherId)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublisherProduct", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.PublisherProduct", "Publisher_PublisherId", "dbo.Publisher");
            DropIndex("dbo.PublisherProduct", new[] { "Product_Id" });
            DropIndex("dbo.PublisherProduct", new[] { "Publisher_PublisherId" });
            DropTable("dbo.PublisherProduct");
            CreateIndex("dbo.Product", "PublisherId");
            AddForeignKey("dbo.Product", "PublisherId", "dbo.Publisher", "PublisherId", cascadeDelete: true);
        }
    }
}
