using MediatR;
using Restaurant.Application.Dishes.Dtos;

namespace Restaurant.Application.Dishes.Queries
{
    public class GetDishesForRestaurantQuery(int RestaurantId) : IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; } = RestaurantId;







    }
}
