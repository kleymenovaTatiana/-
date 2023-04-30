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
    public class staffServiceTest
    {
        private readonly StaffrService service;   
        private readonly Mock<IStaffrRepository> staffRepositoryMoq;
        public staffServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            staffRepositoryMoq = new Mock<IStaffrRepository>();

            repositoryWrapperMoq.Setup(x => x.Staff)
                .Returns(staffRepositoryMoq.Object);

            service = new StaffrService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectStaff() 
        {
            return new List<object[]>
            {
                new object[] { new staff() { Nickname = "", Password = "", Surname = "", Namee = "", MiddleName = "", Mail = "", PhoneNumber = "", Birthdate = DateTime.MaxValue } },
                new object[] { new staff() { Nickname = "mo", Password = "", Surname = "", Namee = "", MiddleName = "", Mail = "", PhoneNumber = "", Birthdate = DateTime.MaxValue } },
                new object[] { new staff() { Nickname = "mo", Password = "", Surname = "Vavilova", Namee = "", MiddleName = "", Mail = "", PhoneNumber = "", Birthdate = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullStaff_ShouldThrowNullArgumentException() 
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            staffRepositoryMoq.Verify(x => x.Create(It.IsAny<staff>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectStaff))]
        public async Task CreateAsyncNewStaffShouldNotCreateNewStaff(staff staff)   
        {
            //arrange
            var newStaff = staff; 

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newStaff));

            //assert
            staffRepositoryMoq.Verify(x => x.Create(It.IsAny<staff>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewStaffShouldCreateNewStaff() 
        {
            var newStaff = new staff() 
            {
                Nickname = "mo",
                Password = "",
                Surname = "Vavilova",
                Namee = "Sofya",
                MiddleName = "Vladimirovna",
                Mail = "ala@mail.ru",
                PhoneNumber = "74725939",
                Birthdate = DateTime.MaxValue
            };

            //act
            await service.Create(newStaff);

            //assert
            staffRepositoryMoq.Verify(x => x.Create(It.IsAny<staff>()), Times.Once);
        }
    }
}
