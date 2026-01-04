using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Exeptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishByIdForRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ILogger<DeleteDishByIdForRestaurantCommandHandler> logger, IDishesRepository dishesRepository) : IRequestHandler<DeleteDishByIdForRestaurantCommand>
    {
        public async Task Handle(DeleteDishByIdForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting Dish with id : {request.DishId} from a restaurant with id : {request.RestaurantId}");

            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant is null)

                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var dishes = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId)
                 ?? throw new NotFoundException(nameof(Restaurant), request.DishId.ToString());



            await dishesRepository.Delete(dishes);
        }
    }
}
