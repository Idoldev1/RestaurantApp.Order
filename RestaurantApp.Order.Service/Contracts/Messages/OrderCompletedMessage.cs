namespace RestaurantApp.Order.Service.Contracts.Messages;


public class OrderCompletedMessage
{
    public string OrderId { get; }
    public string CustomerId { get; }
}