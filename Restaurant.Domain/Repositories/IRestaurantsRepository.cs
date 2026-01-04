using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<RestaurantEntity>> GetAllAsync();
        Task<RestaurantEntity?> GetByIdAsync(int id);

        Task<int> Create(RestaurantEntity entity);

        Task Delete(RestaurantEntity entity);

        Task Update(RestaurantEntity entity);

    }
}
