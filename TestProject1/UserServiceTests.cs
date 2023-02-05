using Moq;
using SaleAppExample.Data;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace TestProject1
{
    public class UserServiceTests
    {
        private Mock<IRepository<Buyer, Guid>> _userRepository;
        private UserStore<Buyer, Guid> _userService;

        public UserServiceTests()
        {
            _userRepository = new Mock<IRepository<Buyer, Guid>>();
        }

        [Fact]
        public async Task GetUserById_ThereIsNoUser_ReturnNull()
        {
            // // Arrange
            // var users = new List<Buyer>();
            // _userRepository.Setup(x => x.GetAll()).Returns(users.AsQueryable());
            //
            // // Act
            // var user = await _userService.AddAsync(users[0], "qweqwe");
            // // Assert
            // Assert.Null(user);
        }

        [Fact]
        public async Task GetUserById_InvalidId_ThrowException()
        {
        }

        [Fact]
        public async Task GetUserById_ThereIsUser_ReturnOne()
        {

        }
    }
}
