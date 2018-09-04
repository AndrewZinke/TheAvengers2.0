namespace WebAPIStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedConnection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "WalletId", "dbo.Wallets");
            DropPrimaryKey("dbo.Wallets");
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
            
            AddColumn("dbo.Wallets", "CustomerId", c => c.Int());
            AddColumn("dbo.Wallets", "Balance", c => c.Double());
            AddColumn("dbo.Wallets", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Wallets", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Wallets", "Id");
            AddForeignKey("dbo.Customers", "WalletId", "dbo.Wallets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Wallet_Id" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropPrimaryKey("dbo.Wallets");
            AlterColumn("dbo.Wallets", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Wallets", "IsActive");
            DropColumn("dbo.Wallets", "Balance");
            DropColumn("dbo.Wallets", "CustomerId");
            DropTable("dbo.Transactions");
            AddPrimaryKey("dbo.Wallets", "Id");
            AddForeignKey("dbo.Customers", "WalletId", "dbo.Wallets", "Id", cascadeDelete: true);
        }
    }
}
