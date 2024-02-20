using AutoMapper;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Commands;
using RestaurantApp.Order.Service.Queries;

namespace RestaurantApp.Order.Service.Mapper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Orders, PlaceOrderCommand>();
        CreateMap<Orders, GetOrderByIdQuery>();
    }
}