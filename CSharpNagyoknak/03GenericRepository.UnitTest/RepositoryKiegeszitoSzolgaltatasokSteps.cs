using _03GenericRepository.Repository;
using System;
using TechTalk.SpecFlow;
using _03GenericRepository.DTO;
using NUnit.Framework;

namespace _03GenericRepository.UnitTest
{
    [Binding]
    public class RepositoryKiegeszitoSzolgaltatasokSteps
    {
        private TodoItemRepository repo;
        private TodoItemDTO todoItem;

        [Given(@"egy TodoItem repository")]
        public void AmennyibenEgyTodoItemRepository()
        {
            repo = new TodoItemRepository();
        }
        
        [Given(@"egy Severity repository")]
        public void AmennyibenEgySeverityRepository()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"betöltök egy TodoItem-et")]
        public void MajdBetoltokEgyTodoItem_Et()
        {
            //todoItem = repo.Find(2);
            //todoItem = repo.Find(2, x=>x.Severity);
            todoItem = repo.Find(x => x.Title == "vegyünk kenyeret", x => x.Severity);
        }
        
        [When(@"betöltök egy Severity elemet")]
        public void MajdBetoltokEgySeverityElemet()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a Severity adatoknak rajta kell lennie")]
        public void AkkorASeverityAdatoknakRajtaKellLennie()
        {
            Assert.IsNotNull(todoItem);
            Assert.IsNotNull(todoItem.Severity);
            Assert.IsFalse(string.IsNullOrWhiteSpace(todoItem.Severity.Title));

        }

        [Then(@"az össze hozzá kapcsolódó TodoItem-nek rajta kell lennie")]
        public void AkkorAzOsszeHozzaKapcsolodoTodoItem_NekRajtaKellLennie()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
