using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Order.Domain.Entities;


public class OrderItem
{
    [Column("Food Id")]
    public string FoodId { get; set; }
    public string FoodName { get; set; }
}