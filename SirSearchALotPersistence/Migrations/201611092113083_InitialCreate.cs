namespace SirSearchALotPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interest",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InterestId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false, maxLength: 5),
                        ImageUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interest", "PersonId", "dbo.Person");
            DropIndex("dbo.Interest", new[] { "PersonId" });
            DropTable("dbo.Person");
            DropTable("dbo.Interest");
        }
    }
}
