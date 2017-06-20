namespace _01Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoItemsClosednullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoItems", "Closed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoItems", "Closed", c => c.DateTime(nullable: false));
        }
    }
}
