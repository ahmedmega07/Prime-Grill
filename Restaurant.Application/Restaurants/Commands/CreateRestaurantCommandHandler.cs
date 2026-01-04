using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands
{
    public class CreateRestaurantCommandHandler(IMapper mapper, IRestaurantsRepository restaurantsRepository, ILogger<CreateRestaurantCommandHandler> logger) : IRequestHandler<CreateRestaurantCommand, int>
    {


        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {

            logger.LogInformation("Creating a new restaurant");

            var newRestaurant = mapper.Map<RestaurantEntity>(request);
            int id = await restaurantsRepository.Create(newRestaurant);

            return id;


        }






    }

}