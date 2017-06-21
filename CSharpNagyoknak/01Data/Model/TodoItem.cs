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
    /// <summary>
    /// Mivel ez az osztály adatbázisba kerül, szükség van arra, hogy 
    /// az adatbázis alapvető összefüggéseit támogassa. Vagyis kell, hogy az 
    /// ebből az osztályból képzett táblának legyen PK-ja (Primary Key: elsődleges kulcs)
    /// </summary>
    public class TodoItem : IClassWithId
    {
        public TodoItem()
        {
            IsDone = false;
            Closed = null;
            Opened = DateTime.Now;
        }

        /// <summary>
        /// A Code First névkonvenció alapú, tehát, ha 
        /// talál egy Id nevű mezőt, akkor feltételezi, hogy ő a kulcs (Key)
        /// amiből az adatbázisban a PK lesz.
        /// hogyha ez a mező int, akkor identity-t készít belőle
        /// </summary>
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime Opened { get; set; }
        public DateTime? Closed { get; set; }

        public int SeverityId { get; set; }
        public Severity Severity { get; set; }
    }
}
