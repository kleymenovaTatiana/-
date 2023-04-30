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
    public class OrderServiceTest
    {
        private readonly OrderService service;
        private readonly Mock<IOrderRepository> orderRepositoryMoq; 
        public OrderServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            orderRepositoryMoq = new Mock<IOrderRepository>();

            repositoryWrapperMoq.Setup(x => x.Order)
                .Returns(orderRepositoryMoq.Object);

            service = new OrderService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectOrder() 
        {
            return new List<object[]>
            {
                new object[] { new Order() { IdUser = 42, LtemNumber = 2, EmployeeCode = 22, DateAndTime = DateTime.MaxValue, Status = "", Quantity = 3, DeliveryMethod = "" } },
                new object[] { new Order() { IdUser = 42, LtemNumber = 2, EmployeeCode = 22, DateAndTime = DateTime.MaxValue, Status = "poluchin", Quantity = 3, DeliveryMethod = "" } },
                new object[] { new Order() { IdUser = 42, LtemNumber = 2, EmployeeCode = 22, DateAndTime = DateTime.MaxValue, Status = "poluchin", Quantity = 3, DeliveryMethod = "pickup" } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullOrder_ShouldThrowNullArgumentException() 
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            orderRepositoryMoq.Verify(x => x.Create(It.IsAny<Order>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectOrder))]
        public async Task CreateAsyncNewOrderShouldNotCreateNewOrder(Order order)   
        {
            //arrange
            var newOrder = order;  

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newOrder));

            //assert
            orderRepositoryMoq.Verify(x => x.Create(It.IsAny<Order>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewOrderShouldCreateNewOrder()
        {
            var newOrder = new Order() 
            {
                IdUser = 42,
                LtemNumber = 2,
                EmployeeCode = 22,
                DateAndTime = DateTime.MaxValue,
                Status = "poluchin",
                Quantity = 3,
                DeliveryMethod = "pickup"
            };

            //act
            await service.Create(newOrder);

            //assert
            orderRepositoryMoq.Verify(x => x.Create(It.IsAny<Order>()), Times.Once);
        }
    }
}
