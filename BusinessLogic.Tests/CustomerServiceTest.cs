using BusinessLogic.Services;
using DataAccess.Models;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic.Tests
{
    public class CustomerServiceTest
    {
        private readonly CustomerService service;
        private readonly Mock<ICustomersRepository> customerRepositoryMoq;
        public CustomerServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            customerRepositoryMoq = new Mock<ICustomersRepository>();

            repositoryWrapperMoq.Setup(x => x.Customer)
                .Returns(customerRepositoryMoq.Object);

            service = new CustomerService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new Customer() { Nickname = "", Password = "", Surname = "", Name = "", MiddleName = "", Mail = "", PhoneNumber = "", Birthdate = DateTime.MaxValue } },
                new object[] { new Customer() { Nickname = "Test", Password = "", Surname = "", Name = "", MiddleName = "", Mail = "", PhoneNumber = "", Birthdate = DateTime.MaxValue } },
                new object[] { new Customer() { Nickname = "Test", Password = "", Surname = "Test", Name = "", MiddleName = "", Mail = "", PhoneNumber = "", Birthdate = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullCustomer_ShouldThrowNullArgumentException()
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            customerRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsyncNewCustomerShouldNotCreateNewCustomer(Customer customer)
        {
            //arrange
            var newCustomer = customer;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newCustomer));

            //assert
            customerRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewCustomerShouldCreateNewCustomer()
        {
            var newCustomer = new Customer()
            {
                Nickname = "Test",
                Password = "",
                Surname = "Test",
                Name = "Test",
                MiddleName = "Test",
                Mail = "test@test.com",
                PhoneNumber = "75003717",
                Birthdate = DateTime.MaxValue
            };

            //act
            await service.Create(newCustomer);

            //assert
            customerRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Once);
        }
    }
}
