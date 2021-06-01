using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Teste.UnitTests.Data
{
    public class CrudUser: BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider serviceProvider;

        public CrudUser(DbTeste dbTeste)
        {
            this.serviceProvider = dbTeste.serviceProvider;        
        }

        [Fact(DisplayName = "Create User")]
        [Trait("CRUD", "UserEntity")]
        public async Task ShouldCreateAUser()
        {
            using(var context = serviceProvider.GetService<MyContext>())
            {
                UserImplementation repository = new UserImplementation(context);
                UserEntity entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Nome = Faker.Name.FullName()
                };

                var createdResult = await repository.InsertAsync(entity);
                Assert.NotNull(createdResult);
                Assert.Equal(entity.Email, createdResult.Email);
                Assert.Equal(entity.Nome, createdResult.Nome);
                Assert.False(createdResult.Id == Guid.Empty);

                entity.Nome = Faker.Name.First();
                var createdResultUpdate = await repository.UpdateAsync(entity);
                Assert.NotNull(createdResult);
                Assert.Equal(entity.Email, createdResultUpdate.Email);
                Assert.Equal(entity.Nome, createdResultUpdate.Nome);


                var resultExists = await repository.ExistAsync(createdResultUpdate.Id);
                Assert.True(resultExists);
                
                var selectResult = await repository.SelectAsync(createdResultUpdate.Id);
                Assert.NotNull(selectResult);
                Assert.Equal(entity.Email, selectResult.Email);
                Assert.Equal(entity.Nome, selectResult.Nome);

                var selectAll = await repository.SelectAsync();
                Assert.NotNull(selectAll);
                Assert.True(selectAll.Count() > 1);

                var removed = await repository.DeleteAsyinc(selectResult.Id);
                Assert.True(removed);
            }
        }
    }
}
