namespace _01Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeverityCreatedcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Severities", "Created", c => c.DateTime(nullable: false, defaultValue: new DateTime(2017,06,20)));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Severities", "Created");
        }
    }
}
