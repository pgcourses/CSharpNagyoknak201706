using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Repository.DTO
{
    public class TodoItemDTO
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
    }
}
