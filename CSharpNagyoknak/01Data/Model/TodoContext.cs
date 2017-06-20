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
        //2. Össze kell kötni az adatokat reprezentáló osztályt az elérési osztállyal.
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
