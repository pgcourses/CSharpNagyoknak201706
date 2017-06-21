using _01Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericRepository.DTO
{
    public class SeverityDTO : IClassWithId
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
