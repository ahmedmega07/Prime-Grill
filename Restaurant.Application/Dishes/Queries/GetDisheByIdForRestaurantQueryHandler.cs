using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Dishes.Dtos;
using Restaurant.Domain.Exeptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Queries
{
    public class GetDisheByIdForRestaurantQueryHandler(ILogger<GetDisheByIdForRestaurantQueryHandler> logger
        , IRestaurantsRepository restaurantsRepository
        , IMapper mapper) : IRequestHandler<GetDisheByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDisheByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {

            logger.LogInformation("Getting dish :{Dishid} with restaurant : {Id}", request.DishId, request.RestaurantId);

            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId)
                ?? throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId)
                ?? throw new NotFoundException(nameof(Restaurant), request.DishId.ToString());

            var Result = mapper.Map<DishDto>(dish);

            return Result;
        }
    }
}
