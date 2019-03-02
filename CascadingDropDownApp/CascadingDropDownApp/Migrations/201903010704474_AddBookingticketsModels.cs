namespace CascadingDropDownApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookingticketsModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingTickets",
                c => new
                    {
                        BookingTicketId = c.Int(nullable: false, identity: true),
                        PassengerName = c.String(),
                        Mobile = c.String(),
                        BookingDate = c.DateTime(nullable: false),
                        TransferFrom = c.Int(nullable: false),
                        TransferTo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingTicketId)
                .ForeignKey("dbo.Districts", t => t.TransferFrom)
                .ForeignKey("dbo.Districts", t => t.TransferTo)
                .Index(t => t.TransferFrom)
                .Index(t => t.TransferTo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingTickets", "TransferTo", "dbo.Districts");
            DropForeignKey("dbo.BookingTickets", "TransferFrom", "dbo.Districts");
            DropIndex("dbo.BookingTickets", new[] { "TransferTo" });
            DropIndex("dbo.BookingTickets", new[] { "TransferFrom" });
            DropTable("dbo.BookingTickets");
        }
    }
}
