namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smsedits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SMS", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.SMS", "User_Id");
            AddForeignKey("dbo.SMS", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SMS", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SMS", new[] { "User_Id" });
            DropColumn("dbo.SMS", "User_Id");
        }
    }
}
