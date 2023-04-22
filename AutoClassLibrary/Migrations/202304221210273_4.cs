namespace AutoClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cars", new[] { "User_UserEmail" });
            DropColumn("dbo.Cars", "UserEmail");
            RenameColumn(table: "dbo.Cars", name: "User_UserEmail", newName: "UserEmail");
            AlterColumn("dbo.Cars", "UserEmail", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "UserEmail");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cars", new[] { "UserEmail" });
            AlterColumn("dbo.Cars", "UserEmail", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Cars", name: "UserEmail", newName: "User_UserEmail");
            AddColumn("dbo.Cars", "UserEmail", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "User_UserEmail");
        }
    }
}
