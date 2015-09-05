namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SMS", "Recipient_Id", c => c.Int());
            CreateIndex("dbo.SMS", "Recipient_Id");
            AddForeignKey("dbo.SMS", "Recipient_Id", "dbo.Contacts", "Id");
            DropColumn("dbo.SMS", "Recipient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SMS", "Recipient", c => c.String());
            DropForeignKey("dbo.SMS", "Recipient_Id", "dbo.Contacts");
            DropIndex("dbo.SMS", new[] { "Recipient_Id" });
            DropColumn("dbo.SMS", "Recipient_Id");
        }
    }
}
