namespace RestaurantApp.Order.Domain.Exceptions;

public sealed class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(string Id) : base ($"The Order with ID {Id} does not exist in the database")
    {
        
    }
}