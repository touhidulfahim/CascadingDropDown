namespace CascadingDropDownApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        ItemCategoryID = c.Guid(nullable: false),
                        ItemCategoryName = c.String(),
                        ShortName = c.String(),
                        ParentCategoryID = c.Guid(),
                    })
                .PrimaryKey(t => t.ItemCategoryID)
                .ForeignKey("dbo.CategoryModels", t => t.ParentCategoryID)
                .Index(t => t.ParentCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryModels", "ParentCategoryID", "dbo.CategoryModels");
            DropIndex("dbo.CategoryModels", new[] { "ParentCategoryID" });
            DropTable("dbo.CategoryModels");
        }
    }
}
