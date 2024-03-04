using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Order.Domain.Entities;


public class OrderItem
{
    [Key]
    //[Column("Foods")]
    public int FoodId { get; set; }
    public string FoodName { get; set; }

    /*[ForeignKey(nameof(Orders))]
    public string OrdersFoodId { get; set;}
    public Orders? Orders { get; set;}*/
}