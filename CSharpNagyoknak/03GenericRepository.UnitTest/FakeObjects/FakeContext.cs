using _01Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _03GenericRepository.UnitTest.FakeObjects
{
    public class FakeContext : TodoContext
    {
        public FakeContext()
        { }

        private List<Severity> severities = new List<Severity>();

        public override DbSet<TodoItem> TodoItems
        {
            get
            {
                return base.TodoItems;
            }

            set
            {
                base.TodoItems = value;
            }
        }

        public override DbSet<Severity> Severities
        {
            get
            {
                return severities; //mivel ez lista, DbSet-té nem tudjuk egyszerűen alakítani
            }

            set
            {
                base.Severities = value;
            }
        }
    }
}
