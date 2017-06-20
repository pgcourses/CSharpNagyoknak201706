using _01Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TodoContext();
            Console.WriteLine(db.TodoItems.Count());
            Console.ReadLine();
        }
    }
}
