



using AutoMapper;
using Restaurant.Application.Restaurants.Commands;
using Restaurant.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;

public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {


        CreateMap<UpdateRestaurantCommand, RestaurantEntity>()
           .ForMember(d => d.Address, opt => opt.MapFrom(s =>
            new Address
            { City = s.City, PostalCode = s.PostalCode, Street = s.Street }));




        CreateMap<CreateRestaurantCommand, RestaurantEntity>()
            .ForMember(d => d.Address, opt => opt.MapFrom(s =>
            new Address
            { City = s.City, PostalCode = s.PostalCode, Street = s.Street }));






        CreateMap<RestaurantEntity, RestaurantDto>()
            .ForMember(d => d.City, o => o.MapFrom(s => s.Address == null ? "" : s.Address.City))
            .ForMember(d => d.PostalCode, o => o.MapFrom(s => s.Address == null ? "" : s.Address.PostalCode))
            .ForMember(d => d.Street, o => o.MapFrom(s => s.Address == null ? "" : s.Address.Street))

            .ForMember(d => d.Dishes, o => o.MapFrom(s => s.Dishes));

    }



}

