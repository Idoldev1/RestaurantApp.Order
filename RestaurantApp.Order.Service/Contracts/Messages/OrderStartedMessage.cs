namespace RestaurantApp.Order.Service.Contracts.Messages;


public class OrderStartedMessage
{
    public string OrderId { get; }
    public string CustomerId { get; }
}