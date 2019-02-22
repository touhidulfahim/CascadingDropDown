namespace CascadingDropDownApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(nullable: false, maxLength: 5),
                        CountryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CountryId)
                .Index(t => t.CountryCode, unique: true)
                .Index(t => t.CountryName, unique: true);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        DivisionId = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        DivisionCode = c.String(nullable: false, maxLength: 5),
                        DivisionName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DivisionId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.DivisionCode, unique: true)
                .Index(t => t.DivisionName, unique: true);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DivisionId = c.Int(nullable: false),
                        DistrictCode = c.String(nullable: false, maxLength: 5),
                        DistrictName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .Index(t => t.DivisionId)
                .Index(t => t.DistrictCode, unique: true)
                .Index(t => t.DistrictName, unique: true);
            
            CreateTable(
                "dbo.Upazilas",
                c => new
                    {
                        UpazilaId = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        UpazilaCode = c.String(nullable: false, maxLength: 5),
                        UpazilaName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UpazilaId)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .Index(t => t.DistrictId)
                .Index(t => t.UpazilaCode, unique: true)
                .Index(t => t.UpazilaName, unique: true);
            
            CreateTable(
                "dbo.UnionParishads",
                c => new
                    {
                        UnionParishadId = c.Int(nullable: false, identity: true),
                        UnionParishadCode = c.String(nullable: false, maxLength: 5),
                        UnionParishadName = c.String(nullable: false, maxLength: 50),
                        UpazilaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnionParishadId)
                .ForeignKey("dbo.Upazilas", t => t.UpazilaId)
                .Index(t => t.UnionParishadCode, unique: true)
                .Index(t => t.UnionParishadName, unique: true)
                .Index(t => t.UpazilaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnionParishads", "UpazilaId", "dbo.Upazilas");
            DropForeignKey("dbo.Upazilas", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Divisions", "CountryId", "dbo.Countries");
            DropIndex("dbo.UnionParishads", new[] { "UpazilaId" });
            DropIndex("dbo.UnionParishads", new[] { "UnionParishadName" });
            DropIndex("dbo.UnionParishads", new[] { "UnionParishadCode" });
            DropIndex("dbo.Upazilas", new[] { "UpazilaName" });
            DropIndex("dbo.Upazilas", new[] { "UpazilaCode" });
            DropIndex("dbo.Upazilas", new[] { "DistrictId" });
            DropIndex("dbo.Districts", new[] { "DistrictName" });
            DropIndex("dbo.Districts", new[] { "DistrictCode" });
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            DropIndex("dbo.Divisions", new[] { "DivisionName" });
            DropIndex("dbo.Divisions", new[] { "DivisionCode" });
            DropIndex("dbo.Divisions", new[] { "CountryId" });
            DropIndex("dbo.Countries", new[] { "CountryName" });
            DropIndex("dbo.Countries", new[] { "CountryCode" });
            DropTable("dbo.UnionParishads");
            DropTable("dbo.Upazilas");
            DropTable("dbo.Districts");
            DropTable("dbo.Divisions");
            DropTable("dbo.Countries");
        }
    }
}
