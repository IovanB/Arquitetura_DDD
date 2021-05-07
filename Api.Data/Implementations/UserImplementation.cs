using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        public DbSet<UserEntity> _database;

        public UserImplementation(MyContext context): base(context)
        {
            _database = context.Set<UserEntity>();
        }
        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _database.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
