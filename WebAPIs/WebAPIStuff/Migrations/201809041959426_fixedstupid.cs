namespace WebAPIStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedstupid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets");
            DropForeignKey("dbo.Customers", "WalletId", "dbo.Wallets");
            DropIndex("dbo.Customers", new[] { "WalletId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Transactions", new[] { "Wallet_Id" });
            DropColumn("dbo.Customers", "WalletId");
            DropTable("dbo.Wallets");
            DropTable("dbo.Transactions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        Wallet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        Balance = c.Double(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "WalletId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "Wallet_Id");
            CreateIndex("dbo.Transactions", "CustomerId");
            CreateIndex("dbo.Customers", "WalletId");
            AddForeignKey("dbo.Customers", "WalletId", "dbo.Wallets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets", "Id");
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
