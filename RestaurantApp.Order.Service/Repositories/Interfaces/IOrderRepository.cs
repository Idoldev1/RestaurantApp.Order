using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Service.Repositories.Interfaces;


public interface IOrderRepository
{
    Task<Orders> PlaceOrderAsync (Orders order);
    Task<Orders> GetOrderByIdAsync(string Id);
    void UpdateOrdersAsync(Orders order);
}