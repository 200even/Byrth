namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityDueDate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contractions", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Contractions", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            AddColumn("dbo.AspNetUsers", "DueDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DueDate");
            RenameIndex(table: "dbo.Contractions", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Contractions", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
