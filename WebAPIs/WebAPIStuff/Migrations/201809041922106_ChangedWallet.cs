namespace WebAPIStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedWallet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets");
            DropForeignKey("dbo.Customers", "WalletId", "dbo.Wallets");
            DropPrimaryKey("dbo.Wallets");
            AlterColumn("dbo.Wallets", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Wallets", "Id");
            AddForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets", "Id");
            AddForeignKey("dbo.Customers", "WalletId", "dbo.Wallets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets");
            DropPrimaryKey("dbo.Wallets");
            AlterColumn("dbo.Wallets", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Wallets", "Id");
            AddForeignKey("dbo.Customers", "WalletId", "dbo.Wallets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets", "Id");
        }
    }
}
