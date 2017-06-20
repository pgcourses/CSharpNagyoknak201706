namespace _01Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_01Data.Model.TodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_01Data.Model.TodoContext";
        }

        protected override void Seed(_01Data.Model.TodoContext context)
        {
            context.Severities.AddOrUpdate(s=>s.Title, new Model.Severity { Title = "Fontos" });
            context.Severities.AddOrUpdate(s=>s.Title, new Model.Severity { Title = "Nem fontos" });
            base.Seed(context);
        }
    }
}
