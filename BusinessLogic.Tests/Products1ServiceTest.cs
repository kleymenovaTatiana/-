using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class Products1ServiceTest
    {
        private readonly Products1Service service;
        private readonly Mock<IProducts1Repository> products1RepositoryMoq; 
        public Products1ServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            products1RepositoryMoq = new Mock<IProducts1Repository>();

            repositoryWrapperMoq.Setup(x => x.Produts1) 
                .Returns(products1RepositoryMoq.Object);

            service = new Products1Service(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectProducts1() 
        {
            return new List<object[]>
            {
                new object[] { new Products1() { CategoryId = 222, Title = "", Cost = 65, Description = "", ArticleNumber = 2460123, NumberInClade = 24 } },
                new object[] { new Products1() { CategoryId = 222, Title = "dry", Cost = 65, Description = "", ArticleNumber = 2460123, NumberInClade = 24 } },
                new object[] { new Products1() { CategoryId = 222, Title = "dry", Cost = 65, Description = "cat food", ArticleNumber = 2460123, NumberInClade = 24 } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullProducts1_ShouldThrowNullArgumentException() 
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            products1RepositoryMoq.Verify(x => x.Create(It.IsAny<Products1>()), Times.Never); 
        }
        [Theory]
        [MemberData(nameof(GetIncorrectProducts1))]
        public async Task CreateAsyncNewProducts1ShouldNotCreateNewProducts1(Products1 produts1)  
        {
            //arrange
            var newProducts1 = produts1; 

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newProducts1));

            //assert
            products1RepositoryMoq.Verify(x => x.Create(It.IsAny<Products1>()), Times.Never); 
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewProduts1ShouldCreateNewProduts1() 
        {
            var newProduts1 = new Products1()   
            {
                CategoryId = 222,
                Title = "dry",
                Cost = 65,
                Description = "cat food",
                ArticleNumber = 2460123,
                NumberInClade = 24
            };

            //act
            await service.Create(newProduts1);

            //assert
            products1RepositoryMoq.Verify(x => x.Create(It.IsAny<Products1>()), Times.Once);
        }
    }
}
