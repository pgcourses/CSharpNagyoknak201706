using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02Repository.DTO;
using _01Data.Model;

namespace _02Repository.Repository
{
    public class TodoItemRepository
    {
        public void Add(TodoItemDTO todoItemDTO)
        {
            //COMMENT: Tervezési kérdés a null érték használata
            //http://netacademia.blog.hu/2017/05/30/miert_ne_hasznaljunk_null-t
            if (null == todoItemDTO)
            {
                throw new ArgumentOutOfRangeException(nameof(todoItemDTO));
            }

            using (var db = new TodoContext())
            {
                //Az azonosító a mentés után jelenik meg, ezért 
                //a példány referenciáját megtartom.
                var todoItem = new TodoItem
                {
                    Id = todoItemDTO.Id,
                    Title = todoItemDTO.Title,
                    IsDone = todoItemDTO.IsDone,
                    Opened = todoItemDTO.Opened,
                    Closed = todoItemDTO.Closed,
                    SeverityId = todoItemDTO.SeverityId
                };

                db.TodoItems.Add(todoItem);

                db.SaveChanges();
                todoItemDTO.Id = todoItem.Id;
            }
        }

        public TodoItemDTO Find(int id)
        {
            using (var db = new TodoContext())
            {
                var todoItem = db.TodoItems.Find(id);
                //COMMENT: Tervezési kérdés a null érték használata
                if (null==todoItem)
                {
                    return null;
                }

                return  new TodoItemDTO {
                    Id = todoItem.Id,
                    Title = todoItem.Title, 
                    IsDone = todoItem.IsDone,
                    Opened = todoItem.Opened,
                    Closed = todoItem.Closed,
                    SeverityId = todoItem.SeverityId
                };
            }
        }

        public void Remove(int todoItemId)
        {
            using (var db = new TodoContext())
            {
                var todoItem = db.TodoItems.Find(todoItemId);
                //COMMENT: null érték használatáról dönteni
                if (null == todoItem)
                {
                    throw new ArgumentOutOfRangeException(nameof(todoItemId));
                }

                db.TodoItems.Remove(todoItem);
                db.SaveChanges();
            }
        }

        public void Update(TodoItemDTO todoItemDTO)
        {
            using (var db=new TodoContext())
            {
                var todoItem = db.TodoItems.Find(todoItemDTO.Id);
                //COMMENT: null érték használatáról dönteni
                if (null==todoItem)
                {
                    throw new ArgumentOutOfRangeException(nameof(todoItemDTO.Id));
                }

                todoItem.Title = todoItemDTO.Title;
                todoItem.IsDone = todoItemDTO.IsDone;
                todoItem.Opened = todoItemDTO.Opened;
                todoItem.Closed = todoItemDTO.Closed;
                todoItem.SeverityId = todoItemDTO.SeverityId;

                db.SaveChanges();
            }
        }
    }
}
