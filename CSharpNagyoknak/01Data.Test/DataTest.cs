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
            var db = new TodoContext();

            //Arrange
            var count = db.TodoItems.Count();

            //Assert
            Assert.AreEqual(0, count);
        }
    }
}
