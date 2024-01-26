using Microsoft.EntityFrameworkCore;
using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Data.DataAccess;


public class OrderDb : DbContext
{
    public OrderDb(DbContextOptions<OrderDb> options) : base(options)
    {
        
    }


    public DbSet<Orders> Orders{ get; set; }
}