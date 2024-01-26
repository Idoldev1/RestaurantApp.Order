namespace RestaurantApp.Order.Service.Contracts.Messages;


public interface OrderCompletedMessage
{
    public string OrderId { get; }
    public string CustomerId { get; }
}