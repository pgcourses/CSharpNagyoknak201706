using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericRepository.Repository
{
    public class GenericRepository
    {
        public GenericRepository()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<TodoItemProfile>());
        }

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

                var todoItem = Mapper.Map<TodoItem>(todoItemDTO);

                db.TodoItems.Add(todoItem);

                db.SaveChanges();
                todoItemDTO.Id = todoItem.Id;
            }
        }

        public void AddWithId(TodoItemDTO todoItemDTO)
        {
            //
            //COMMENT: Tervezési kérdés a null érték használata
            //http://netacademia.blog.hu/2017/05/30/miert_ne_hasznaljunk_null-t
            if (null == todoItemDTO)
            {
                throw new ArgumentOutOfRangeException(nameof(todoItemDTO));
            }

            using (var db = new TodoContext())
            {
                //todo: tranzakció
                db.Database.ExecuteSqlCommand("set identity_insert dbo.TodoItems on");

                //Az azonosító a mentés után jelenik meg, ezért 
                //a példány referenciáját megtartom.
                var todoItem = Mapper.Map<TodoItem>(todoItemDTO);

                db.TodoItems.Add(todoItem);

                db.SaveChanges();

                db.Database.ExecuteSqlCommand("set identity_insert dbo.TodoItems off");

                todoItemDTO.Id = todoItem.Id;
            }
        }

        public TodoItemDTO Find(int id)
        {
            using (var db = new TodoContext())
            {
                var todoItem = db.TodoItems.Find(id);
                //COMMENT: Tervezési kérdés a null érték használata
                if (null == todoItem)
                {
                    return null;
                }

                return Mapper.Map<TodoItemDTO>(todoItem);
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
            using (var db = new TodoContext())
            {
                var todoItem = db.TodoItems.Find(todoItemDTO.Id);
                //COMMENT: null érték használatáról dönteni
                if (null == todoItem)
                {
                    throw new ArgumentOutOfRangeException(nameof(todoItemDTO.Id));
                }

                Mapper.Map(todoItemDTO, todoItem);

                db.SaveChanges();
            }
        }
    }
}
