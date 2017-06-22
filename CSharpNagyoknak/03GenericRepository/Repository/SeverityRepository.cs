using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericRepository.Repository
{
    public class SeverityRepository : GenericRepository<Severity, SeverityDTO, SeverityProfile>
    {
        /// <summary>
        /// Ez a konstruktor biztosítja az utat a DI paraméter beküldéséhez
        /// muszáj, enélkül nem lehet Unit tesztelni
        /// </summary>
        /// <param name="db"></param>
        public SeverityRepository(TodoContext db) : base(db)
        { }

        /// <summary>
        /// Az előző konstruktor miatt a fordító nem generál paraméternélküli konstruktort, 
        /// így ezt nekünk kell legyártani. Hogy jól működjön, meg kell hívnunk
        /// a alaposztály paraméter nélküli konstruktorát
        /// </summary>
        public SeverityRepository() : base()
        { }
    }
}
