using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Service.Repositories.Interfaces;


public interface IOrderRepository
{
    void PlaceOrderAsync (Orders order);
    Task<Orders> GetOrderByIdAsync(string id);
    void UpdateOrdersAsync(Orders order);
}