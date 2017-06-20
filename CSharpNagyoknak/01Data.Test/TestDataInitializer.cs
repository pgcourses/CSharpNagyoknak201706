using _01Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Data.Test
{
    public class TestDataInitializer : DropCreateDatabaseAlways<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            context.Severities.AddOrUpdate(s => s.Title, new Model.Severity { Title = "Baromi fontos" });
            context.Severities.AddOrUpdate(s => s.Title, new Model.Severity { Title = "Kit érdekel" });

            base.Seed(context);
        }
    }
}
