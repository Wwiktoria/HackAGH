namespace AutoClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        Regnum = c.String(),
                        Name = c.String(),
                        Speed = c.Double(nullable: false),
                        Lights = c.Int(nullable: false),
                        EmergencyLights = c.Boolean(nullable: false),
                        Doorsopen = c.Boolean(nullable: false),
                        UserEmail = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Vin)
                .ForeignKey("dbo.Users", t => t.UserEmail)
                .Index(t => t.UserEmail);
            
            CreateTable(
                "dbo.Raports",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Log = c.String(),
                        Vin = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.Cars", t => t.Vin)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Telnr = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.EmergencyPersons",
                c => new
                    {
                        EmergencyPersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Nrtel = c.String(),
                        UserEmail = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmergencyPersonID)
                .ForeignKey("dbo.Users", t => t.UserEmail)
                .Index(t => t.UserEmail);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmergencyPersons", "UserEmail", "dbo.Users");
            DropForeignKey("dbo.Cars", "UserEmail", "dbo.Users");
            DropForeignKey("dbo.Raports", "Vin", "dbo.Cars");
            DropIndex("dbo.EmergencyPersons", new[] { "UserEmail" });
            DropIndex("dbo.Raports", new[] { "Vin" });
            DropIndex("dbo.Cars", new[] { "UserEmail" });
            DropTable("dbo.EmergencyPersons");
            DropTable("dbo.Users");
            DropTable("dbo.Raports");
            DropTable("dbo.Cars");
        }
    }
}
