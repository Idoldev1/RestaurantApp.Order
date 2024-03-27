using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Order.API.ActionFilter;
using RestaurantApp.Order.Service.Commands;
using RestaurantApp.Order.Service.Queries;

namespace RestaurantApp.Order.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpGet(Name = "OrderById")]
    public async Task<IActionResult> GetOrderById(string orderId)
    {
            var query = new GetOrderByIdQuery{OrderId = orderId};
            var order = await _mediator.Send(query);
            return Ok(order);
    }


    [HttpPost("placeOrder")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand placeOrderCommand)
    {
        /*if (placeOrderCommand == null)
                return BadRequest("The Order details is empty. Please input valid details");


        if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);*/

                
        var orderId = await _mediator.Send(placeOrderCommand) ?? throw new Exception("Invalid details. Please try again");

        // You can customize the response based on the result
        return Ok(orderId);
    }

}