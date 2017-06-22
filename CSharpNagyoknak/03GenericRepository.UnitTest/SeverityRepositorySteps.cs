using _01Data.Model;
using _03GenericRepository.Repository;
using _03GenericRepository.UnitTest.FakeObjects;
using Moq;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace _03GenericRepository.UnitTest
{
    [Binding]
    public class SeverityRepositorySteps
    {
        private SeverityRepository sut;

        [Given(@"egy SeverityRepository")]
        public void AmennyibenEgySeverityRepository()
        {
            //sut = new SeverityRepository(new FakeContext());

            var mockContext = new Mock<TodoContext>();
            sut = new SeverityRepository(mockContext.Object);
        }
        
        [When(@"egy új elemet rögzítek a SeverityRepository-ban")]
        public void MajdEgyUjElemetRogzitekASeverityRepository_Ban()
        {
            sut.Add(new DTO.SeverityDTO { Title = "Ez itt egy akármi bármi" });
        }
        
        [When(@"rákeresek egy létező elemre a SeverityRepository-ban")]
        public void MajdRakeresekEgyLetezoElemreASeverityRepository_Ban()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"törlök egy létező elemet a SeverityRepository-ból,")]
        public void MajdTorlokEgyLetezoElemetASeverityRepository_Bol()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"módosítok egy meglévő elemet SeverityRepository-ban")]
        public void MajdModositokEgyMeglevoElemetSeverityRepository_Ban()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"annak látszódnia kell a SeverityRepository-ban\.")]
        public void AkkorAnnakLatszodniaKellASeverityRepository_Ban_()
        {
            var severity = sut.Find(s => s.Title == "Ez itt egy akármi bármi");
            Assert.IsNotNull(severity);
        }
        
        [Then(@"annak el kell tűnnie SeverityRepository-ból")]
        public void AkkorAnnakElKellTunnieSeverityRepository_Bol()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a módosításnak látszódnia kell a SeverityRepository-ban")]
        public void AkkorAModositasnakLatszodniaKellASeverityRepository_Ban()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
