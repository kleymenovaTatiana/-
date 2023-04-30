using BusinessLogic.Services;
using DataAccess.Models;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class CategoryServiceTest 
    {
        private readonly CategoryService service;
        private readonly Mock<ICategoryRepository> categoryRepositoryMoq; 
        public CategoryServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            categoryRepositoryMoq = new Mock<ICategoryRepository>();

            repositoryWrapperMoq.Setup(x => x.Category)
                .Returns(categoryRepositoryMoq.Object);

            service = new CategoryService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCategory()
        {
            return new List<object[]>
            {
                new object[] { new Category() { CategoryName = "" } },
                new object[] { new Category() { CategoryName = "For_hamsters" } },
                new object[] { new Category() { CategoryName = "For_hamsters" } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullCategory_ShouldThrowNullArgumentException()
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            categoryRepositoryMoq.Verify(x => x.Create(It.IsAny<Category>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCategory))]
        public async Task CreateAsyncNewCategoryShouldNotCreateNewCategory(Category category)
        {
            //arrange
            var newCategory = category;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newCategory));

            //assert
            categoryRepositoryMoq.Verify(x => x.Create(It.IsAny<Category>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewCategoryShouldCreateNewCategory()
        {
            var newCategory = new Category()
            {
                CategoryName = "For_hamsters"
            };

            //act
            await service.Create(newCategory);

            //assert
            categoryRepositoryMoq.Verify(x => x.Create(It.IsAny<Category>()), Times.Once);
        }
    }
}
