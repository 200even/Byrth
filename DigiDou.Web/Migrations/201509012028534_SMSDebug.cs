namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDebug : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SMS", "Recipient_Id", "dbo.Contacts");
            DropIndex("dbo.SMS", new[] { "Recipient_Id" });
            AddColumn("dbo.SMS", "Recipient", c => c.String());
            DropColumn("dbo.SMS", "Recipient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SMS", "Recipient_Id", c => c.Int());
            DropColumn("dbo.SMS", "Recipient");
            CreateIndex("dbo.SMS", "Recipient_Id");
            AddForeignKey("dbo.SMS", "Recipient_Id", "dbo.Contacts", "Id");
        }
    }
}
