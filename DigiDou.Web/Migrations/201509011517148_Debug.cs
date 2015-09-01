namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Debug : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contractions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Contractions", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Contractions");
        }
    }
}
