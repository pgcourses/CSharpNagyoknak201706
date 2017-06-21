using System;
using NUnit.Framework;
using _02Repository.Repository;
using _02Repository.DTO;
using AutoMapper;
using _02Repository.AutoMapper;
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
                SeverityId = 3
            };

            try
            {
                //Arrange
                sut.Add(todoItem);
                var newTotoItem = sut.Find(todoItem.Id);

                //Assert
                Assert.IsNotNull(newTotoItem);
                Assert.AreEqual(todoItem.Title, newTotoItem.Title);
            }
            finally
            {
                sut.Remove(todoItem.Id);
            }

        }

        [Test]
        public void TodoItemRepositoryTests_DeleteItemShouldBeDisappearInRepo() //D
        {
            //Act
            var sut = new TodoItemRepository();

            //var todoItem = sut.Find(1); 
            // sut.Remove(todoItem); //repo törlés, ld. az Info.txt-ben

            try
            {
                //Arrange
                var todoItemId = 1;
                sut.Remove(todoItemId);
                var newTotoItem = sut.Find(todoItemId);

                //Assert
                Assert.IsNull(newTotoItem);

            }
            finally
            {
                var todoItem = new TodoItemDTO { Id = 1, Title = "vegyünk tejet", SeverityId = 1 };
                sut.AddWithId(todoItem);
            }
        }

        [Test]
        public void TodoItemRepositoryTests_ExistingItemShouldBeFindableInRepo() //R
        {
            var sut = new TodoItemRepository();

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
            Assert.IsNotNull(todoItem, "Nincs tesztadat (Id=1)!");

            try
            {
                todoItem.Title = "Ez egy új feladatleírás";
                sut.Update(todoItem);

                var newTodoItem = sut.Find(1);
                Assert.IsNotNull(newTodoItem);

                //Assert
                Assert.AreEqual("Ez egy új feladatleírás", newTodoItem.Title);

            }
            finally
            {
                todoItem.Title = "vegyünk tejet";
                sut.Update(todoItem);
            }
        }
        [Test]
        public void TodoItemRepositoryTests_AutoMapperConfigurationShouldBeValid() //U
        {
            //Act, Arrange
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<TodoItemProfile>());
            //Assert
            mapperConfig.AssertConfigurationIsValid();
        }
    }
}