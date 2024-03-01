using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Order.Domain.Entities;


public class OrderItem
{
    [Key]
    [Column("Food Id")]
    public string FoodId { get; set; }
    public string FoodName { get; set; }
}