using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Az adatok adatbázisba mentéséhez létre kell hozni az
/// adatainkat reprezentáló POCO osztályokat
/// </summary>

namespace _01Data.Model
{
    public class TodoItem
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime Opened { get; set; }
        public DateTime Closed { get; set; }
    }
}
