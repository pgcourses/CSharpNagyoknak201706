using _03GenericRepository.Repository;
using _03GenericRepository.UnitTest.FakeObjects;
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
            sut = new SeverityRepository(new FakeContext());
        }
        
        [When(@"egy új elemet rögzítek a SeverityRepository-ban")]
        public void MajdEgyUjElemetRogzitekASeverityRepository_Ban()
        {
            ScenarioContext.Current.Pending();
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
            ScenarioContext.Current.Pending();
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
