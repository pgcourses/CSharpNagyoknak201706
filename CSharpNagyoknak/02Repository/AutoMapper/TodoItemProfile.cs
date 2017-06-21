using _01Data.Model;
using _02Repository.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Repository.AutoMapper
{
    /// <summary>
    /// Az adatok átalakításának a paraméterezése
    /// </summary>
    public class TodoItemProfile : Profile
    {
        /// <summary>
        /// A szabályokat a konstruktorban hozzuk létre
        /// </summary>
        public TodoItemProfile()
        {
            CreateMap<TodoItemDTO, TodoItem>();
            CreateMap<TodoItem, TodoItemDTO>();
        }
    }
}
