using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;

namespace Restaurant.Infrastructure.Repositories
{
    public class RestaurantsRepository(ApplicationDbContext context) : IRestaurantsRepository
    {
        public async Task<int> Create(RestaurantEntity entity)
        {
            context.Restaurants.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(RestaurantEntity entity)
        {
            context.Restaurants.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RestaurantEntity>> GetAllAsync()
        {
            return await context.Restaurants
                .Include(r => r.Dishes)
                .ToListAsync();
        }

        public async Task<RestaurantEntity?> GetByIdAsync(int id)
        {
            return await context.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Update(RestaurantEntity entity)
        {
            context.Restaurants.Update(entity);
            await context.SaveChangesAsync();

        }
    }
}
