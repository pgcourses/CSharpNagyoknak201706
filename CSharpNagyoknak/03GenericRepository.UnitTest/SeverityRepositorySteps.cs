using _01Data.Model;
using _03GenericRepository.Repository;
using _03GenericRepository.UnitTest.FakeObjects;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            var mockContext = MockContextFactory();
            sut = new SeverityRepository(mockContext);
        }

        private static TodoContext MockContextFactory()
        {
            //sut = new SeverityRepository(new FakeContext());

            var mockContext = new Mock<TodoContext>();

            //A Strict beállítás segítségével a Mock mindig szól, ha olyan 
            //dolgot használnak a Mockolt példányon, ami nincs beállítva.

            //1. feladat: 
            //Moq.MockException : DbContext.Set<TodoItem>() invocation failed with mock behavior Strict.
            //All invocations on the mock must have a corresponding setup.
            //Vagyis: válaszolni erre a hívásra: DbContext.Set<TodoItem>()

            //mockContext.Setup(ctx => ctx.Set<TodoItem>()) //Abban az esetben ha ezt a függvényt hívják
            //           .Returns();                      //Arra ezt kell válaszolni.

            //2. Ebből következő feladat, hogy legyen DbSet<TodoItem> osztályunk.
            //Viszont, ebből meg az látszik, hogy vannak számunkra lényegtelen belső hívások,
            //amiknek az implementálása csak az időt viszi. Vagyis, ezt nem folytatjuk.

            //3. Az biztos, hogy kell majd valami lista a Severity példányokból, amin munkálkodik a dublőr
            var list = new List<Severity>(new Severity[] {
                new Severity { Id=1, Title="Baromi fontos" },
                new Severity { Id=2, Title="Kit érdekel" },
            });

            var mockDbSet = new Mock<DbSet<Severity>>();

            mockDbSet.As<IQueryable<Severity>>()
                     .Setup(iqueriable => iqueriable.Provider)
                     .Returns(list.AsQueryable().Provider);

            mockDbSet.As<IQueryable<Severity>>()
                     .Setup(iqueriable => iqueriable.Expression)
                     .Returns(list.AsQueryable().Expression);

            mockDbSet.As<IQueryable<Severity>>()
                     .Setup(iqueriable => iqueriable.ElementType)
                     .Returns(list.AsQueryable().ElementType);

            mockDbSet.As<IQueryable<Severity>>()
                     .Setup(iqueriable => iqueriable.GetEnumerator())
                     .Returns(list.AsQueryable().GetEnumerator());

            //4. Ahhoz, hogy hozzáadni tudjunk, kell az Add függvény setupja a DbSet-en
            mockDbSet.Setup(set => set.Add(It.IsAny<Severity>())) //jelzem, hogy az add bármilyen paramétere esetén él ez a setup
                     .Callback<Severity>(severity => //jelzem a várt paraméter típusát, és utána használhatom
                     {
                         severity.Id = list.Count + 1; //szimuláljuk a listába felvételkor, hogy az azonosító ugrik egyet.
                         list.Add(severity);
                     });

            //5. Ahhoz, hogy keresni tudjunk, a DbSet-nek tudnia kell keresni
            mockDbSet.Setup(set => set.Find(It.IsAny<object[]>())) //bármilyen objektumtömb esetén (A DbSet fel van készítve kompozit indexekre is, vagyis, ha az index több mezőből áll)
                     .Returns<object[]>(keyValues => list.Find(x => x.Id == (int)keyValues[0])); //mi csak egy mezőt használunk, és ez int, tehát ezt leírhatom.


            //Extra: hogy kell az update-et és a deletet setupolni:
            //delete
            mockDbSet.Setup(set => set.Remove(It.IsAny<Severity>()))
                     .Callback<Severity>(severity => list.Remove(severity));

            //update
            //COMMENT: hogy kell az Update-et mockolni???
            //Nem kell mockolni, az Update magától jól működik.
            //mivel a find a listaelem referenciáját adja vissza, így a 
            //property-k módosítása jó helyre megy.

            //6. Végül, a DbContext-nek megadjuk az így felparaméterezett DbSet-et, hogy ezt adja vissza, ha
            //   valaki kéri tőle.
            mockContext.Setup(ctx => ctx.Set<Severity>()) //Abban az esetben ha ezt a függvényt hívják
                       .Returns(mockDbSet.Object);      //Arra ezt kell válaszolni.

            //7. Legvégül, kész a TodoContext, ezt adom át a repositorynak, így ezt fogja tudni használni.
            return mockContext.Object;
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
            //var severity = sut.Find(3);  //Így kell, ha nem tudunk IQueryable felületet mockolni

            //Így pedig, ha tudunk
            var severity = sut.Find(x=>x.Title=="Ez itt egy akármi bármi");
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
