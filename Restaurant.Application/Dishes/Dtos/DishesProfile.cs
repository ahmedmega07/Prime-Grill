using AutoMapper;
using Restaurant.Application.Dishes.Commands.CreateDish;
using Restaurant.Application.Dishes.Commands.UpdateDish;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Dishes.Dtos
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<CreateDishCommand, Dish>();
            CreateMap<UpdateDishCommand, Dish>();
            CreateMap<Dish, DishDto>();
        }
    }
}
