using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantApp.Order.Data.DataAccess;

namespace RestaurantApp.Order.API.AppDbContext;


public class OrderContextFactory : IDesignTimeDbContextFactory<OrderDb>
{
    public OrderDb CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


        var builder = new DbContextOptionsBuilder<OrderDb>()

        .UseSqlite(configuration.GetConnectionString("OrderDbConnection"),
            b => b.MigrationsAssembly("RestaurantApp.Order.API"));
        


        return new OrderDb(builder.Options);
    }
}
