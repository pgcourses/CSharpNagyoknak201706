using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Az adatok adatbázisba mentéséhez létre kell hozni az
/// adatbázissal kapcsolatot tartó osztályt
/// </summary>

namespace _01Data.Model
{
    public class TodoContext : DbContext //1. le kell származni a DbContext-ből
    {

        /// <summary>
        /// A paraméter nélküli létrehozó, ami továbbhívja a paraméterest
        /// és beállítja paraméterként a DefaultConnection nevű
        /// kapcsolati karakterláncot.
        /// </summary>
        public TodoContext() : this("name=DefaultConnection")
        { }

        /// <summary>
        /// Meg akarjuk hívni a bázisosztály paraméteres létrehozóját,
        /// méghozzá a megfelelő paraméterrel, így készítek
        /// egy saját paraméteres konstruktort,
        /// és a bejövő paramétert egyszerűen továbbdobom.
        /// </summary>
        /// <param name="nameOrConnectionString">A bázisosztály által elvárt paraméter, 
        /// vagy egy kapcsolati karakterlánc vagy egy karakterláncnak a neve ami be 
        /// van állítva pl. az appconfig.ban</param>
        public TodoContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        //2. Össze kell kötni az adatokat reprezentáló osztályt az elérési osztállyal.
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Severity> Severities { get; set; }
    }
}
