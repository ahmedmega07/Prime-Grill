using MediatR;

namespace Restaurant.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishByIdForRestaurantCommand(int RestaurantId, int DishId) : IRequest
    {
        public int RestaurantId { get; } = RestaurantId;
        public int DishId { get; } = DishId;
    }
}
