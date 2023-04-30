using BusinessLogic.Services;
using DataAccess.Models;
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
    public class FilterServiceTest 
    {
        private readonly filterService service;
        private readonly Mock<IfilterRepository> filterRepositoryMoq;  
        public FilterServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            filterRepositoryMoq = new Mock<IfilterRepository>();

            repositoryWrapperMoq.Setup(x => x.Filter)
                .Returns(filterRepositoryMoq.Object); 

            service = new filterService(repositoryWrapperMoq.Object); 
        }
        public static IEnumerable<object[]> GetIncorrectFilter() 
        {
            return new List<object[]>
            {
                new object[] { new Filter() { Feed = "", Toys = "", Bowls = "", Aquariums = "" } },
                new object[] { new Filter() { Feed = "Yami", Toys = "", Bowls = "", Aquariums = "" } },
                new object[] { new Filter() { Feed = "Yami", Toys = "Tetra", Bowls = "", Aquariums = "" } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullFilter_ShouldThrowNullArgumentException() 
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            filterRepositoryMoq.Verify(x => x.Create(It.IsAny<Filter>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectFilter))]
        public async Task CreateAsyncNewFilterShouldNotCreateNewFilter(Filter filter)   
        {
            //arrange
            var newFilter = filter;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newFilter));

            //assert
            filterRepositoryMoq.Verify(x => x.Create(It.IsAny<Filter>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewFilterShouldCreateNewFilter()
        {
            var newFilter = new Filter()
            {
                Feed = "Yami",
                Toys = "Tetra",
                Bowls = "No",
                Aquariums = "Moderna"
            };

            //act
            await service.Create(newFilter);

            //assert
            filterRepositoryMoq.Verify(x => x.Create(It.IsAny<Filter>()), Times.Once);
        }
    }
}
