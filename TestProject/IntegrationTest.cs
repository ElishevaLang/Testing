using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Moq.EntityFrameworkCore;
using MyNewCiniesOction.DAL;
using MyNewCiniesOction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class UserRepositoryIntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly ChiniesOctionContext _dbContext;
        private readonly UserDal _userRepository;

        public UserRepositoryIntegrationTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _userRepository = new UserDal(_dbContext);

        }

        [Fact]
        public async Task GetUserByEmailAndPassword_ValidCredentials_ReturnsUser()
        {
            //Array
            var email = "test@gmail.com";
            var password ="1111";
            var user = new User { UserEmail = email, Password = password, FirstName = "Test First Name", LastName = "Test Last Name", UserPhone="9999",UserIsAdmin=true };
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            //Act
            var result = await _userRepository.GetUserByEmailAndPassword(email, password);
            
            //Assert
            Assert.NotNull(result);
        }
    }
}






