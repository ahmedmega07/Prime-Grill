using MediatR;
using Restaurant.Application.Dishes.Dtos;

namespace Restaurant.Application.Dishes.Queries
{
    public class GetDisheByIdForRestaurantQuery(int RestaurantId, int dishId) : IRequest<DishDto>
    {

        public int RestaurantId { get; } = RestaurantId;
        public int DishId { get; } = dishId;
    }
}
