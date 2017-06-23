using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02Repository.DTO;
using _01Data.Model;
using AutoMapper;
using _02Repository.AutoMapper;
using System.Data.SqlClient;

namespace _02Repository.Repository
{
    public class TodoItemRepository
    {
        public TodoItemRepository()
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
            //COMMENT: Tervezési kérdés a null érték használata
            //http://netacademia.blog.hu/2017/05/30/miert_ne_hasznaljunk_null-t
            if (null == todoItemDTO)
            {
                throw new ArgumentOutOfRangeException(nameof(todoItemDTO));
            }

            using (var db = new TodoContext())
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    db.Database.ExecuteSqlCommand("set identity_insert dbo.TodoItems on");

                    db.Database.ExecuteSqlCommand("insert TodoItems (Id,Title,IsDone,Opened,Closed,SeverityId) values (@Id,@Title,@IsDone,@Opened,@Closed,@SeverityId)",
                        new SqlParameter("@Id", todoItemDTO.Id),
                        new SqlParameter("@Title", todoItemDTO.Title),
                        new SqlParameter("@IsDone", todoItemDTO.IsDone),
                        new SqlParameter("@Opened", todoItemDTO.Opened),
                        new SqlParameter("@Closed", (object)todoItemDTO.Closed ?? DBNull.Value),
                        new SqlParameter("@SeverityId", todoItemDTO.SeverityId)
                        );


                    db.Database.ExecuteSqlCommand("set identity_insert dbo.TodoItems off");
                    tran.Commit();
                }
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
            using (var db=new TodoContext())
            {
                var todoItem = db.TodoItems.Find(todoItemDTO.Id);
                //COMMENT: null érték használatáról dönteni
                if (null==todoItem)
                {
                    throw new ArgumentOutOfRangeException(nameof(todoItemDTO.Id));
                }

                Mapper.Map(todoItemDTO, todoItem);

                db.SaveChanges();
            }
        }
    }
}
