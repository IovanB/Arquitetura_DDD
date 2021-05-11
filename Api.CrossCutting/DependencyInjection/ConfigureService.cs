using Api.Data.Context;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>(); /*toda vez que injetar a dependencia, instancia a classe UserServuce*/
            service.AddTransient<ILoginService, LoginService>();
            service.AddDbContext<MyContext>(
                 //Soptions => options.UseMySql("Server=localhost;Port=3306;Database=DbAPI;Uid=root;Pwd=root");
                 options => options.UseSqlServer("Server =.\\SQLEXPRESS2019; Initial Catalog = dbapi; MultipleActiveResultSets = true; User ID = sa; Password = 123456"));
                 //options => options.UseSqlServer(ConfigurationManager.ConnectionStrings["db1"].ConnectionString));

        }
    }
}
