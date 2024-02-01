namespace RestaurantApp.Order.Service.Contracts.Messages;


public record OrderCompletedMessage(string OrderId, string CustomerId);