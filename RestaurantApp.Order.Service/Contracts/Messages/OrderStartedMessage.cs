namespace RestaurantApp.Order.Service.Contracts.Messages;


public interface OrderStartedMessage
{
    public string OrderId { get; }
    public string CustomerId { get; }
}