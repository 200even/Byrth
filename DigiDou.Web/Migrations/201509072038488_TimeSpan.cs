namespace DigiDou.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeSpan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contractions", "TimeSinceLast", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contractions", "TimeSinceLast");
        }
    }
}
