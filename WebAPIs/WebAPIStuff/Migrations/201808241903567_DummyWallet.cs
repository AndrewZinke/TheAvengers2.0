namespace WebAPIStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DummyWallet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "WalletId");
            AddForeignKey("dbo.Customers", "WalletId", "dbo.Wallets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "WalletId", "dbo.Wallets");
            DropIndex("dbo.Customers", new[] { "WalletId" });
            DropTable("dbo.Wallets");
        }
    }
}
