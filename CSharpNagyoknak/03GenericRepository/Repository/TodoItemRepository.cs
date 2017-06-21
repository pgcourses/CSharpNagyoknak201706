using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace _03GenericRepository.Repository
{
    public class TodoItemRepository : GenericRepository<TodoItem, TodoItemDTO, TodoItemProfile>
    {
        //Mivel megoldottuk általánosan, ezt ki tudjuk dobni
        //public TodoItemDTO FindWithSeverity(int id, params Expression<Func<TodoItem, object>>[] includeParams)
        //{
        //    using (var db = new TodoContext())
        //    {
        //        var query = db.TodoItems
        //                      .AsQueryable();

        //        foreach (var include in includeParams)
        //        {
        //            query = query.Include(include);
        //        }

        //        //var item = db.TodoItems
        //        //             //.Include(x=>x.Severity)   //a lambdával ilyet definiálunk  (TodoItem) => { return object; }
        //        //             .Include(include)
        //        //             .SingleOrDefault(x => x.Id == id);

        //        var item = query.SingleOrDefault(x => x.Id == id);
        //        //COMMENT: Tervezési kérdés a null érték használata
        //        if (null == item)
        //        {
        //            return null;
        //        }

        //        return Mapper.Map<TodoItemDTO>(item);
        //    }
        //}
    }
}
