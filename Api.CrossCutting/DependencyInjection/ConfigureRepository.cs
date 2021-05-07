using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>)); /*add scoped é usado para banco de dados, pois a cada nova conexao tem uma nova instancia*/
            service.AddScoped<IUserRepository, UserImplementation>(); 

        }
    }
}
