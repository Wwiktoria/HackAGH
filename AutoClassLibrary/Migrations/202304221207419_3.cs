namespace AutoClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "User_Email", "dbo.Users");
            RenameColumn(table: "dbo.Cars", name: "User_Email", newName: "User_UserEmail");
            RenameIndex(table: "dbo.Cars", name: "IX_User_Email", newName: "IX_User_UserEmail");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Cars", "UserEmail", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserEmail", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "UserEmail");
            AddForeignKey("dbo.Cars", "User_UserEmail", "dbo.Users", "UserEmail");
            DropColumn("dbo.Cars", "Email");
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Cars", "Email", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "User_UserEmail", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "UserEmail");
            DropColumn("dbo.Cars", "UserEmail");
            AddPrimaryKey("dbo.Users", "Email");
            RenameIndex(table: "dbo.Cars", name: "IX_User_UserEmail", newName: "IX_User_Email");
            RenameColumn(table: "dbo.Cars", name: "User_UserEmail", newName: "User_Email");
            AddForeignKey("dbo.Cars", "User_Email", "dbo.Users", "Email");
        }
    }
}
