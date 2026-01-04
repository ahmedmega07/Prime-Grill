using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exeptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Commands.UpdateDish
{
    public class UpdateDishCommandHandler(ILogger<UpdateDishCommandHandler> logger, IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository, IMapper mapper) : IRequestHandler<UpdateDishCommand>
    {
        public async Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating dish {DishId} for restaurant {RestaurantId}", request.RestaurantId);

            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId)
                ?? throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.Id)
                ?? throw new NotFoundException(nameof(Dish), request.Id.ToString());

            mapper.Map(request, dish);

            await dishesRepository.Update(dish);
        }
    }
}