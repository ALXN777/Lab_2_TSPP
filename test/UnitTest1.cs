using Xunit;
using TodoApp;
using System;

namespace TodoApp.Tests
{
    public class ItemServiceTests
    {
        
        [Fact]
        public void Add_ValidTitle_ShouldAddItem()
        {
            var service = new ItemService();
            var item = service.Add("Купити молоко");

            Assert.NotNull(item);
            Assert.Equal("Купити молоко", item.Title);
        }

      
        [Fact]
        public void Add_EmptyTitle_ShouldThrowException()
        {
            var service = new ItemService();
            Assert.Throws<ArgumentException>(() => service.Add(""));
        }

        
        [Fact]
        public void Delete_ExistingItem_ShouldRemoveIt()
        {
            var service = new ItemService();
            var item = service.Add("Зайва задача");

            service.Delete(item.Id);

            Assert.Empty(service.GetAll());
        }


        [Fact]
        public void Complete_ValidId_ShouldChangeStatus()
        {
            var service = new ItemService();
            var item = service.Add("Вивчити С#");

            service.Complete(item.Id);   

            Assert.True(item.IsCompleted);
        }
    }
}