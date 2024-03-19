using Microsoft.EntityFrameworkCore;
using RestaurantApp.Order.Data.DataAccess;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Repositories.Implementation;


public class OrderRepository : IOrderRepository
{
    private readonly OrderDb _orderDb;

    public OrderRepository(OrderDb orderDb)
    {
        _orderDb = orderDb;
    }

    public void PlaceOrderAsync(Orders order)
    {
        _orderDb.Orders.Add(order);
        _orderDb.SaveChangesAsync();

    }

    public async Task<Orders> GetOrderByIdAsync(string id)
    {
        return await _orderDb.Orders.Include(o => o.OrderItems).SingleOrDefaultAsync(o => o.OrderId == id);
    }

    public void UpdateOrdersAsync(Orders order)
    {
        _orderDb.Entry(order).State = EntityState.Modified;

        _orderDb.SaveChanges();
    }
}