using Api.Data.Context;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>(); /*toda vez que injetar a dependencia, instancia a classe UserServuce*/
            service.AddTransient<ILoginService, LoginService>();
            service.AddDbContext<MyContext>(
                 options => options.UseMySql("Server=localhost;Port=3306;Database=DbAPI;Uid=root;Pwd=root")
            );


        }
    }
}
