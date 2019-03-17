namespace CascadingDropDownApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomernCustomerAddressModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAddress",
                c => new
                    {
                        CustomerAddressId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PresentCountryId = c.Int(nullable: false),
                        PresentDivisionId = c.Int(nullable: false),
                        PresentDistrictId = c.Int(nullable: false),
                        PresentUpazilaId = c.Int(nullable: false),
                        PresentUnionParishadId = c.Int(nullable: false),
                        PresentHome = c.String(nullable: false),
                        PresentRoadNo = c.String(nullable: false),
                        PresentVillage = c.String(nullable: false),
                        PermanentCountryId = c.Int(nullable: false),
                        PermanentDivisionId = c.Int(nullable: false),
                        PermanentDistrictId = c.Int(nullable: false),
                        PermanentUpazillaId = c.Int(nullable: false),
                        PermanentUnionParishadId = c.Int(nullable: false),
                        PermanentHome = c.String(nullable: false),
                        PermanentRoadNo = c.String(nullable: false),
                        PermanentVillage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerAddressId)
                .ForeignKey("dbo.Countries", t => t.PermanentCountryId)
                .ForeignKey("dbo.Districts", t => t.PermanentDistrictId)
                .ForeignKey("dbo.Divisions", t => t.PermanentDivisionId)
                .ForeignKey("dbo.UnionParishads", t => t.PermanentUnionParishadId)
                .ForeignKey("dbo.Upazilas", t => t.PermanentUpazillaId)
                .ForeignKey("dbo.Countries", t => t.PresentCountryId)
                .ForeignKey("dbo.Districts", t => t.PresentDistrictId)
                .ForeignKey("dbo.Divisions", t => t.PresentDivisionId)
                .ForeignKey("dbo.UnionParishads", t => t.PresentUnionParishadId)
                .ForeignKey("dbo.Upazilas", t => t.PresentUpazilaId)
                .Index(t => t.PresentCountryId)
                .Index(t => t.PresentDivisionId)
                .Index(t => t.PresentDistrictId)
                .Index(t => t.PresentUpazilaId)
                .Index(t => t.PresentUnionParishadId)
                .Index(t => t.PermanentCountryId)
                .Index(t => t.PermanentDivisionId)
                .Index(t => t.PermanentDistrictId)
                .Index(t => t.PermanentUpazillaId)
                .Index(t => t.PermanentUnionParishadId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerAddress", "PresentUpazilaId", "dbo.Upazilas");
            DropForeignKey("dbo.CustomerAddress", "PresentUnionParishadId", "dbo.UnionParishads");
            DropForeignKey("dbo.CustomerAddress", "PresentDivisionId", "dbo.Divisions");
            DropForeignKey("dbo.CustomerAddress", "PresentDistrictId", "dbo.Districts");
            DropForeignKey("dbo.CustomerAddress", "PresentCountryId", "dbo.Countries");
            DropForeignKey("dbo.CustomerAddress", "PermanentUpazillaId", "dbo.Upazilas");
            DropForeignKey("dbo.CustomerAddress", "PermanentUnionParishadId", "dbo.UnionParishads");
            DropForeignKey("dbo.CustomerAddress", "PermanentDivisionId", "dbo.Divisions");
            DropForeignKey("dbo.CustomerAddress", "PermanentDistrictId", "dbo.Districts");
            DropForeignKey("dbo.CustomerAddress", "PermanentCountryId", "dbo.Countries");
            DropIndex("dbo.CustomerAddress", new[] { "PermanentUnionParishadId" });
            DropIndex("dbo.CustomerAddress", new[] { "PermanentUpazillaId" });
            DropIndex("dbo.CustomerAddress", new[] { "PermanentDistrictId" });
            DropIndex("dbo.CustomerAddress", new[] { "PermanentDivisionId" });
            DropIndex("dbo.CustomerAddress", new[] { "PermanentCountryId" });
            DropIndex("dbo.CustomerAddress", new[] { "PresentUnionParishadId" });
            DropIndex("dbo.CustomerAddress", new[] { "PresentUpazilaId" });
            DropIndex("dbo.CustomerAddress", new[] { "PresentDistrictId" });
            DropIndex("dbo.CustomerAddress", new[] { "PresentDivisionId" });
            DropIndex("dbo.CustomerAddress", new[] { "PresentCountryId" });
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerAddress");
        }
    }
}
