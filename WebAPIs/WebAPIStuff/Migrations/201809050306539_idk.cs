namespace WebAPIStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "shares", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "shares");
        }
    }
}
