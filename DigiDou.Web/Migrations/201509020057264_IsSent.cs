namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SMS", "IsSent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SMS", "IsSent");
        }
    }
}
