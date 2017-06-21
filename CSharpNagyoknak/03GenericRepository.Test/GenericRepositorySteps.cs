using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using _03GenericRepository.Repository;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace _03GenericRepository.Test
{
    [Binding]
    public class GenericRepositorySteps
    {
        private GenericRepository<TodoItem, TodoItemDTO, TodoItemProfile> repo;
        private TodoItemDTO todoItem;

        [Given(@"egy GenericRepo")]
        public void AmennyibenEgyGenericRepo()
        {
            repo = new GenericRepository<TodoItem, TodoItemDTO, TodoItemProfile>();
        }
        
        [When(@"egy új elemet rögzítek")]
        public void MajdEgyUjElemetRogzitek()
        {
            todoItem = new TodoItemDTO
            {
                Title = "Tejet venni a palacsintához",
                IsDone = false,
                Opened = DateTime.Now,
                Closed = null,
                SeverityId = 3
            };

            repo.Add(todoItem);
            todoItem = repo.Find(todoItem.Id);
            Console.WriteLine("Új elem visszakeresve: {0}", JsonConvert.SerializeObject(todoItem));
        }

        [When(@"rákeresek egy létező elemre")]
        public void MajdRakeresekEgyLetezoElemre()
        {
            todoItem = repo.Find(2);
            Console.WriteLine("Elem visszakeresve: {0}", JsonConvert.SerializeObject(todoItem));
        }

        [When(@"törlök egy létező elemet,")]
        public void MajdTorlokEgyLetezoElemet()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"módosítok egy meglévő elemet")]
        public void MajdModositokEgyMeglevoElemet()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"annak látszódnia kell a repoban\.")]
        public void AkkorAnnakLatszodniaKellARepoban_()
        {
            Assert.IsNotNull(todoItem);
            todoItem = null;
        }
        
        [Then(@"annak el kell tűnnie")]
        public void AkkorAnnakElKellTunnie()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a módosításnak látszódnia kell")]
        public void AkkorAModositasnakLatszodniaKell()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
