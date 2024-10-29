using Moq;
using Moq.EntityFrameworkCore;
using MyNewCiniesOction.DAL;
using MyNewCiniesOction.Models;

namespace TestProject
{
    public class UserRepositoryUnitTest
    {

        //  Happy-Path
        //DAL
        [Fact]
        public async void GetUserByEmailAndPassword_ValidCredentials_ReturnsUser()
        {
            //Arrange
            var user = new User { UserEmail = "test@gmail.com" , Password = "1111"};

            var mockContext = new Mock<ChiniesOctionContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.User).ReturnsDbSet(users);

            var userRepository = new UserDal(mockContext.Object);

            //Act
            var result = await userRepository.GetUserByEmailAndPassword(user.UserEmail, user.Password);

            //Assert 
            Assert.Equal(user, result);
        }
    }
}