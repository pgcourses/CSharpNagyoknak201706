using System;
using NUnit.Framework;
using _02Repository.Repository;
using _02Repository.DTO;
/// <summary>
/// A repository feladatai:
/// 
/// CRUD: Create, Read, Update, Delete
/// 
/// Ezekhez tartozó integrációs tesztek
/// </summary>
namespace _02Repository.Test
{
    [TestFixture]
    public class TodoItemRepositoryTests
    {
        [Test]
        public void TodoItemRepositoryTests_AddItemShouldBeAppearInRepo() //C
        {
            //Act
            var sut = new TodoItemRepository();

            var todoItem = new TodoItemDTO
            {
                Title = "Tejet venni a palacsintához",
                IsDone = false,
                Opened = DateTime.Now,
                Closed = null,
                //TODO: (RepoTest) a 3-as Severityt létrehozni a tesztadatok közé
                SeverityId = 3
            };

            //Arrange
            sut.Add(todoItem);
            var newTotoItem = sut.Find(todoItem.Id);

            //Assert
            Assert.IsNotNull(newTotoItem);
            Assert.AreEqual(todoItem.Title, newTotoItem.Title);

            //TODO: visszaállítani az adatbázis (repository) eredeti állapotát
        }

        [Test]
        public void TodoItemRepositoryTests_DeleteItemShouldBeDisappearInRepo() //D
        {
            //Act
            var sut = new TodoItemRepository();

            //var todoItem = sut.Find(1); 
            // sut.Remove(todoItem); //repo törlés, ld. az Info.txt-ben

            //Arrange
            //TODO: (RepoTest) biztosítani 1-es TodoItem-et a tesztadatokban
            var todoItemId = 1;
            sut.Remove(todoItemId);
            var newTotoItem = sut.Find(todoItemId);

            //Assert
            Assert.IsNull(newTotoItem);

            //TODO: visszaállítani az adatbázis (repository) eredeti állapotát
        }

        [Test]
        public void TodoItemRepositoryTests_ExistingItemShouldBeFindableInRepo() //R
        {
            var sut = new TodoItemRepository();

            //TODO: (RepoTest) biztosítani 1-es TodoItem-et a tesztadatokban
            var todoItem = sut.Find(2);

            Assert.IsNotNull(todoItem);
        }

        [Test]
        public void TodoItemRepositoryTests_UpdateExistingItemShouldBeAppearInRepo() //U
        {
            //Act
            var sut = new TodoItemRepository();

            //Arrange
            var todoItem = sut.Find(1);

            //TODO: (RepoTest) biztosítani 1-es TodoItem-et a tesztadatokban, aminek nem ez a címe
            todoItem.Title = "Ez egy új feladatleírás";
            sut.Update(todoItem);

            var newTodoItem = sut.Find(1);

            //Assert
            Assert.AreEqual("Ez egy új feladatleírás", newTodoItem.Title);


            //TODO: visszaállítani az adatbázis (repository) eredeti állapotát
        }

    }
}