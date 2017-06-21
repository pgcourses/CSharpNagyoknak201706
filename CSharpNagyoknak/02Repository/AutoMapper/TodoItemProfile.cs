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
            CreateMap<TodoItemDTO, TodoItem>()
                //ha nincs felsorolva itt a property, akkor névazonosság alapján értéket másolunk
                //ha csak céloldalon van, a forrásban nincs, akkor így jelezzük, hogy nem kell vele foglalkozni
                .ForMember(d=>d.Severity, o=>o.Ignore())
                //Így pedig adatkonverziót tudunk előírni
                //csupa nagybetűvé alakítjuk az adatokat
                //.ForMember(d=>d.Title, o=>o.MapFrom(s=>s.Title.ToUpper()))
                ;


            CreateMap<TodoItem, TodoItemDTO>()
                //csupa kisbetűvé alakítjuk az adatokat
                //.ForMember(d => d.Title, o => o.MapFrom(s => s.Title.ToLower()))
                ;
        }
    }
}
