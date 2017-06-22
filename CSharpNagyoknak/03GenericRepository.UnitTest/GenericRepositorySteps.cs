using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using _03GenericRepository.Repository;
using System;
using TechTalk.SpecFlow;

namespace _03GenericRepository.UnitTest
{
    [Binding]
    public class GenericRepositorySteps
    {
        private GenericRepository<TodoItem, TodoItemDTO, TodoItemProfile> sut;

        [Given(@"egy GenericRepo")]
        public void AmennyibenEgyGenericRepo()
        {
            sut = new GenericRepository<TodoItem, TodoItemDTO, TodoItemProfile>();
        }
        
        [When(@"egy új elemet rögzítek")]
        public void MajdEgyUjElemetRogzitek()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"rákeresek egy létező elemre")]
        public void MajdRakeresekEgyLetezoElemre()
        {
            ScenarioContext.Current.Pending();
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
            ScenarioContext.Current.Pending();
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
