namespace Bookazon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rachelsLatestUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "TypeofAudience", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Quantity");
            DropColumn("dbo.Product", "TypeofAudience");
        }
    }
}
