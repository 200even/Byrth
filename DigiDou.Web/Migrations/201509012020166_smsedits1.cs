namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smsedits1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "SMS_Id", "dbo.SMS");
            DropIndex("dbo.Contacts", new[] { "SMS_Id" });
            AddColumn("dbo.SMS", "Recipient_Id", c => c.Int());
            CreateIndex("dbo.SMS", "Recipient_Id");
            AddForeignKey("dbo.SMS", "Recipient_Id", "dbo.Contacts", "Id");
            DropColumn("dbo.Contacts", "SMS_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "SMS_Id", c => c.Int());
            DropForeignKey("dbo.SMS", "Recipient_Id", "dbo.Contacts");
            DropIndex("dbo.SMS", new[] { "Recipient_Id" });
            DropColumn("dbo.SMS", "Recipient_Id");
            CreateIndex("dbo.Contacts", "SMS_Id");
            AddForeignKey("dbo.Contacts", "SMS_Id", "dbo.SMS", "Id");
        }
    }
}
