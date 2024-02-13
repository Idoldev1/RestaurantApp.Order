using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Commands;
using RestaurantApp.Order.Service.Queries;

namespace RestaurantApp.Order.API.Controllers;


[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpGet]
    public async Task<IActionResult> GetOrderById(string orderId)
    {
            var query = new GetOrderByIdQuery{OrderId = orderId};
            var order = await _mediator.Send(query);
            return Ok(order);
    }


    [HttpPost("placeOrder")]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand placeOrderCommand)
    {
        var orderId = await _mediator.Send(placeOrderCommand);

        if(string.IsNullOrEmpty(orderId))
        {
            throw new Exception("Invalid details. Please try again");
        }

        // You can customize the response based on the result
        return Ok(orderId);
    }

}