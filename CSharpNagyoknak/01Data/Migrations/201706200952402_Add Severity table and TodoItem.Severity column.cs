namespace _01Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeveritytableandTodoItemSeveritycolumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Severities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TodoItems", "Severity_Id", c => c.Int());
            CreateIndex("dbo.TodoItems", "Severity_Id");
            AddForeignKey("dbo.TodoItems", "Severity_Id", "dbo.Severities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "Severity_Id", "dbo.Severities");
            DropIndex("dbo.TodoItems", new[] { "Severity_Id" });
            DropColumn("dbo.TodoItems", "Severity_Id");
            DropTable("dbo.Severities");
        }
    }
}
