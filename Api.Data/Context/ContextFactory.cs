using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=.\\SQLEXPRESS2019;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=123456"; 
            //var connectionString = "Server=localhost;Port=3306;Database=DbAPI;Uid=root;Pwd=root";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["db1"].ConnectionString);
            
            return new MyContext(optionsBuilder.Options);

        }
    }
}
