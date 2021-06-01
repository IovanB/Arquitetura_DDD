using Api.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Teste.UnitTests.Service.User
{
    public class UserTest
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameChanged { get; set; }
        public static string UserEmailChanged { get; set; }
        public static Guid UserId { get; set; }
        public List<UserDto> UserList = new List<UserDto>();
        public UserDto userDto;

        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult ;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult ;

        public UserTest()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameChanged = Faker.Name.FullName();
            UserEmailChanged = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                UserList.Add(dto);
            }

            userDto = new UserDto
            {
                Id = UserId,
                Nome = UserName
            };

            userDtoCreate = new UserDtoCreate
            {
                Nome = UserName,
                Email = UserEmail
            };
                      
            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = UserId,
                Nome = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = UserId,
                Nome = UserName,
                Email = UserEmail
            };


            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = UserId,
                Nome = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow
            };

        }

    }
}
