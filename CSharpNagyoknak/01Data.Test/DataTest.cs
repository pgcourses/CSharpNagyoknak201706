using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01Data.Model;
using System.Linq;

namespace _01Data.Test
{
    /// <summary>
    /// Figyelem, mivel a TodoContext magával húzza a teljes adatbázist,
    /// így a tesztjeink nem unit tesztek hanem integrációs tesztek.
    /// </summary>
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void DataTest_TodoItems_CountShouldBe0()
        {
            //AAA: Act, Arrange, Assert

            //Act
            //todo: a DbContext-et így nem szabad használni, javítani kell!
            var db = new TodoContext();

            //Arrange
            var count = db.TodoItems.Count();

            //Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void DataTest_TodoItems_CountAfterAddShouldBe1()
        {
            //Act
            //SUT: System Under Test
            var sut = new TodoContext();

            //Arrange
            sut.TodoItems.Add(new TodoItem {
                //Id //Az Id-t nem kell megadni, mert az adatbázisban képződik, onnan jön
                Title = "Tejet venni a palacsintához",
                IsDone = false,
                Opened = DateTime.Now,
                Closed = DateTime.Now
            });

            sut.SaveChanges();

            var count = sut.TodoItems.Count();

            //Assert
            Assert.AreEqual(1, count);

        }
    }
}
