namespace Bookazon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RachelOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "StarRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "StarRating");
        }
    }
}
