using _01Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericRepository.DTO
{
    public class TodoItemDTO : IClassWithId
    {
        public TodoItemDTO()
        {
            IsDone = false;
            Closed = null;
            Opened = DateTime.Now;
        }
        public DateTime? Closed { get; set; }
        public bool IsDone { get; set; }
        public DateTime Opened { get; set; }
        public string Title { get; set; }
        public int SeverityId { get; set; }
        public int Id { get; set; }
        public SeverityDTO Severity { get; set; }
    }
}
