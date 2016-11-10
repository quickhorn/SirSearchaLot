namespace SirSearchALotPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "City");
        }
    }
}
