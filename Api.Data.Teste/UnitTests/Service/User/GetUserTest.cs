using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Teste.UnitTests.Service.User
{
    public class GetUserTest : UserTest
    {
        private  IUserService userService;
        private Mock<IUserService> mock;

        [Fact(DisplayName = "Is the get method working?")]
        public async Task ShouldExecuteGetMethod()
        {
            mock = new Mock<IUserService>(); /*instanciando o mock*/
            mock.Setup(m => m.Get(UserId)).ReturnsAsync(userDto); /*configurando o mock para retornar um id*/

            userService = mock.Object;

            var result = await userService.Get(UserId);

            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(UserName, result.Nome);

            mock = new Mock<IUserService>(); 
            mock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null)); 
            userService = mock.Object;

            var record = await userService.Get(UserId);
            Assert.Null(record);
        }
    }
}
