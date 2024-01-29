using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Service.Repositories.Interfaces;


public interface IOrderRepository
{
    Task<string> PlaceOrderAsync (Orders order);
    Task<Orders?> GetOrderByIdAsync(string Id);
    Task UpdateOrdersAsync(Orders order);
}