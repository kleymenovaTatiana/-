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
    public class BasketBuyerServiceTest
    {
        private readonly Basket_BuyerService service;
        private readonly Mock<IBasket_BuyerRepository> basket_BuyerRepositoryMoq;
        public BasketBuyerServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            basket_BuyerRepositoryMoq = new Mock<IBasket_BuyerRepository>();

            repositoryWrapperMoq.Setup(x => x.BasketBuyer) 
                .Returns(basket_BuyerRepositoryMoq.Object);

            service = new Basket_BuyerService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectBasket_Buyer() 
        {
            return new List<object[]>
            {
                new object[] { new BasketBuyer() { LtemNumber = 11, Quantity = 40 } },
                new object[] { new BasketBuyer() { LtemNumber = 11, Quantity = 40 } },
                new object[] { new BasketBuyer() { LtemNumber = 11, Quantity = 40 } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullBasketBuyer_ShouldThrowNullArgumentException() 
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            basket_BuyerRepositoryMoq.Verify(x => x.Create(It.IsAny<BasketBuyer>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectBasket_Buyer))]
        public async Task CreateAsyncNewBasket_BuyerShouldNotCreateNewBasket_Buyer(BasketBuyer basketBuyer)
        {
            //arrange
            var newBasketBuyer = basketBuyer; 

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newBasketBuyer));

            //assert
            basket_BuyerRepositoryMoq.Verify(x => x.Create(It.IsAny<BasketBuyer>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewBasketBuyerShouldCreateNewBasketBuyer() 
        {
            var newBasketBuyer = new BasketBuyer()
            {
                LtemNumber = 11,
                Quantity = 40
            };

            //act
            await service.Create(newBasketBuyer);

            //assert
            basket_BuyerRepositoryMoq.Verify(x => x.Create(It.IsAny<BasketBuyer>()), Times.Once);
        }
    }
}
