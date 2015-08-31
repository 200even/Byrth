namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Hospital_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Hospital_Id");
            AddForeignKey("dbo.AspNetUsers", "Hospital_Id", "dbo.Hospitals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.AspNetUsers", new[] { "Hospital_Id" });
            DropColumn("dbo.AspNetUsers", "Hospital_Id");
        }
    }
}
