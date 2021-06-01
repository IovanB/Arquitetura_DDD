using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Data.Teste.UnitTests.Data
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
                
        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        
        public ServiceProvider serviceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(c =>
               c.UseMySql("Server=localhost;Port=3306;Database=DbAPI;Uid=root;Pwd=root"),
               ServiceLifetime.Transient /*muitas requisicoes feitas, precisa colocar o lifetime*/
            );

            serviceProvider = serviceCollection.BuildServiceProvider();

            using(var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {

            using (var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted(); /*Parar a conexao*/
            }
        }
    }
}
