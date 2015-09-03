namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserOnClasses : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contacts", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Contacts", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Contacts", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Contacts", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
