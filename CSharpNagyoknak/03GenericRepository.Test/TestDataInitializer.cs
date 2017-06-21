using _01Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericRepository.Test
{
    public class TestDataInitializer : DropCreateDatabaseAlways<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            context.Severities.AddOrUpdate(s => s.Title, new Severity { Title = "Baromi fontos" });
            context.Severities.AddOrUpdate(s => s.Title, new Severity { Title = "Kit érdekel" });

            context.TodoItems.AddOrUpdate(s => s.Title, new TodoItem { Title = "vegyünk tejet", SeverityId = 1 });
            context.TodoItems.AddOrUpdate(s => s.Title, new TodoItem { Title = "vegyünk kenyeret", SeverityId = 1 });
            context.TodoItems.AddOrUpdate(s => s.Title, new TodoItem { Title = "vegyünk vajat", SeverityId = 1 });

            base.Seed(context);
        }
    }
}
