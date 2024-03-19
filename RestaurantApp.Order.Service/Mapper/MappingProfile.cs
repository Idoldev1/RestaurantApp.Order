using AutoMapper;
using RestaurantApp.Order.Domain.Dtos;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Commands;
using RestaurantApp.Order.Service.Queries;

namespace RestaurantApp.Order.Service.Mapper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        /*CreateMap<PlaceOrderCommand, Orders>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));*/

        CreateMap<Orders, GetOrderDto>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
        CreateMap<OrderItemDto, OrderItem>();

        CreateMap<Orders, GetOrderDto>();
        
    }
}