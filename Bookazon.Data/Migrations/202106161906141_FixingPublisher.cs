namespace Bookazon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingPublisher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PublisherProduct", "Publisher_PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.PublisherProduct", "Product_Id", "dbo.Product");
            DropIndex("dbo.PublisherProduct", new[] { "Publisher_PublisherId" });
            DropIndex("dbo.PublisherProduct", new[] { "Product_Id" });
            AddColumn("dbo.Product", "Publisher_PublisherId", c => c.Int());
            AddColumn("dbo.Publisher", "Product_Id", c => c.Int());
            CreateIndex("dbo.Product", "PublisherId");
            CreateIndex("dbo.Product", "Publisher_PublisherId");
            CreateIndex("dbo.Publisher", "Product_Id");
            AddForeignKey("dbo.Product", "Publisher_PublisherId", "dbo.Publisher", "PublisherId");
            AddForeignKey("dbo.Product", "PublisherId", "dbo.Publisher", "PublisherId", cascadeDelete: true);
            AddForeignKey("dbo.Publisher", "Product_Id", "dbo.Product", "Id");
            DropTable("dbo.PublisherProduct");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PublisherProduct",
                c => new
                    {
                        Publisher_PublisherId = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publisher_PublisherId, t.Product_Id });
            
            DropForeignKey("dbo.Publisher", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Product", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.Product", "Publisher_PublisherId", "dbo.Publisher");
            DropIndex("dbo.Publisher", new[] { "Product_Id" });
            DropIndex("dbo.Product", new[] { "Publisher_PublisherId" });
            DropIndex("dbo.Product", new[] { "PublisherId" });
            DropColumn("dbo.Publisher", "Product_Id");
            DropColumn("dbo.Product", "Publisher_PublisherId");
            CreateIndex("dbo.PublisherProduct", "Product_Id");
            CreateIndex("dbo.PublisherProduct", "Publisher_PublisherId");
            AddForeignKey("dbo.PublisherProduct", "Product_Id", "dbo.Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PublisherProduct", "Publisher_PublisherId", "dbo.Publisher", "PublisherId", cascadeDelete: true);
        }
    }
}
