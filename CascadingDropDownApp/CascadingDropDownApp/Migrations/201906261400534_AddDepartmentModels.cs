namespace CascadingDropDownApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.hr_Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 10),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        DateOfEntry = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .Index(t => t.DepartmentCode, unique: true)
                .Index(t => t.DepartmentName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.hr_Departments", new[] { "DepartmentName" });
            DropIndex("dbo.hr_Departments", new[] { "DepartmentCode" });
            DropTable("dbo.hr_Departments");
        }
    }
}
