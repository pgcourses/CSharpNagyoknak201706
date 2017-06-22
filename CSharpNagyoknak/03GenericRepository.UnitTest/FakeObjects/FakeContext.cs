using _01Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _03GenericRepository.UnitTest.FakeObjects
{
    /// <summary>
    /// FIGYELEM, ez egyáltalán nem jó irány
    /// </summary>
    public class FakeContext : TodoContext
    {
        public FakeContext()
        { }

        private List<Severity> severities = new List<Severity>(); //Ez tartalmazhatná az adatokat
        private DbSet<Severity> severitiesSet; //= new DbSet<Severity>(); //Ezt egyáltalán nem lehet így példányosítani

        //public override DbSet<TodoItem> TodoItems
        //{
        //    get
        //    {
        //        return base.TodoItems;
        //    }

        //    set
        //    {
        //        base.TodoItems = value;
        //    }
        //}

        //public override DbSet<Severity> Severities
        //{
        //    get
        //    {
        //        //return severities; //mivel ez lista, DbSet-té nem tudjuk egyszerűen alakítani
        //        return severitiesSet; 
        //    }

        //    set
        //    {
        //        base.Severities = value;
        //    }
        //}
    }
}
