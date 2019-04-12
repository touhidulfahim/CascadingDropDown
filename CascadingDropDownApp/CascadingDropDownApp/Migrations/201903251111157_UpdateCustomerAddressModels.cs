namespace CascadingDropDownApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerAddressModels : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CustomerAddress", "CustomerId");
            AddForeignKey("dbo.CustomerAddress", "CustomerId", "dbo.Customer", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerAddress", "CustomerId", "dbo.Customer");
            DropIndex("dbo.CustomerAddress", new[] { "CustomerId" });
        }
    }
}
