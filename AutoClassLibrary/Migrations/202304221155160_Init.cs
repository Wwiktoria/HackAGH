namespace AutoClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                        Email = c.Int(nullable: false),
                        User_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Vin)
                .ForeignKey("dbo.Users", t => t.User_Email)
                .Index(t => t.User_Email);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "User_Email", "dbo.Users");
            DropIndex("dbo.Cars", new[] { "User_Email" });
            DropTable("dbo.Users");
            DropTable("dbo.Cars");
        }
    }
}
