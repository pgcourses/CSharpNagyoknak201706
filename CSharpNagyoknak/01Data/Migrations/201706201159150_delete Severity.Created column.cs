namespace _01Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteSeverityCreatedcolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Severities", "Created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Severities", "Created", c => c.DateTime(nullable: false));
        }
    }
}
