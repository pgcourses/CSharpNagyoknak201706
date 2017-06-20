namespace _01Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTodoItemSeverityIdcolumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TodoItems", "Severity_Id", "dbo.Severities");
            DropIndex("dbo.TodoItems", new[] { "Severity_Id" });
            RenameColumn(table: "dbo.TodoItems", name: "Severity_Id", newName: "SeverityId");
            AlterColumn("dbo.TodoItems", "SeverityId", c => c.Int(nullable: false));
            CreateIndex("dbo.TodoItems", "SeverityId");
            AddForeignKey("dbo.TodoItems", "SeverityId", "dbo.Severities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "SeverityId", "dbo.Severities");
            DropIndex("dbo.TodoItems", new[] { "SeverityId" });
            AlterColumn("dbo.TodoItems", "SeverityId", c => c.Int());
            RenameColumn(table: "dbo.TodoItems", name: "SeverityId", newName: "Severity_Id");
            CreateIndex("dbo.TodoItems", "Severity_Id");
            AddForeignKey("dbo.TodoItems", "Severity_Id", "dbo.Severities", "Id");
        }
    }
}
