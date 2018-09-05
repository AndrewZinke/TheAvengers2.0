namespace WebAPIStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleasework : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "shares", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "change");
            DropColumn("dbo.Stocks", "perChange");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "perChange", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "change", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Stocks", "shares");
        }
    }
}
