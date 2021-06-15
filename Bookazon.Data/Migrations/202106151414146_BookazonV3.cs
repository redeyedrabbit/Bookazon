namespace Bookazon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookazonV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "TypeofAudience", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "TypeofAudience");
        }
    }
}
