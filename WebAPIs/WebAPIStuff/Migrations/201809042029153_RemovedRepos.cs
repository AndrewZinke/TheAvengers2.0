namespace WebAPIStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRepos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shares",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        stockID = c.Int(nullable: false),
                        customerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.customerID, cascadeDelete: true)
                .ForeignKey("dbo.Stocks", t => t.stockID, cascadeDelete: true)
                .Index(t => t.stockID)
                .Index(t => t.customerID);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        PPS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        symbol = c.String(),
                        low = c.Decimal(nullable: false, precision: 18, scale: 2),
                        high = c.Decimal(nullable: false, precision: 18, scale: 2),
                        change = c.Decimal(nullable: false, precision: 18, scale: 2),
                        perChange = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Wallets", t => t.Wallet_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Wallet_Id);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        Balance = c.Double(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets");
            DropForeignKey("dbo.Wallets", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Shares", "stockID", "dbo.Stocks");
            DropForeignKey("dbo.Shares", "customerID", "dbo.Customers");
            DropIndex("dbo.Wallets", new[] { "CustomerId" });
            DropIndex("dbo.Transactions", new[] { "Wallet_Id" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Shares", new[] { "customerID" });
            DropIndex("dbo.Shares", new[] { "stockID" });
            DropTable("dbo.Wallets");
            DropTable("dbo.Transactions");
            DropTable("dbo.Stocks");
            DropTable("dbo.Shares");
        }
    }
}
