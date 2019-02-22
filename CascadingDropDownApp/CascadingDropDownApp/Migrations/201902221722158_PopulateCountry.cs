namespace CascadingDropDownApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCountry : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Countries (CountryCode, CountryName) VALUES('BAN', 'Bangladesh')");
            Sql("INSERT INTO Countries (CountryCode, CountryName) VALUES('USA', 'United States of America')");
            Sql("INSERT INTO Countries (CountryCode, CountryName) VALUES('IND', 'INDIA')");
            Sql("INSERT INTO Countries (CountryCode, CountryName) VALUES('PAK', 'PAKISTAN')");

        }

        public override void Down()
        {
        }
    }
}
