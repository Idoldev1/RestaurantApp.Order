using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Service.Repositories.Interfaces;


public interface IOrderRepository
{
    Task<string> PlaceOrderAsync (Orders order);
}