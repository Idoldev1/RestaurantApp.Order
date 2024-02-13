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

    public async Task<string> PlaceOrderAsync(Orders order)
    {
        _orderDb.Orders.Add(order);
        await _orderDb.SaveChangesAsync();

        return order.OrderId;
    }

    public async Task<Orders> GetOrderByIdAsync(string Id)
    {
        return await _orderDb.Orders.FirstOrDefaultAsync(o => o.OrderId == Id);
    }

    public async Task UpdateOrdersAsync(Orders order)
    {
        _orderDb.Entry(order).State = EntityState.Modified;

        await _orderDb.SaveChangesAsync();
    }
}