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

    public async Task GetOrderByIdAsync(string Id)
    {
        var order = await _orderDb.Orders.FirstOrDefault(Id);
    }
}