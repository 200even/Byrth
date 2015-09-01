namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SMS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(maxLength: 140),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "SMS_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "SMS_Id");
            AddForeignKey("dbo.Contacts", "SMS_Id", "dbo.SMS", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "SMS_Id", "dbo.SMS");
            DropIndex("dbo.Contacts", new[] { "SMS_Id" });
            DropColumn("dbo.Contacts", "SMS_Id");
            DropTable("dbo.SMS");
        }
    }
}
