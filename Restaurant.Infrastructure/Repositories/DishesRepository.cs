using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;

namespace Restaurant.Infrastructure.Repositories
{
    public class DishesRepository(ApplicationDbContext context) : IDishesRepository
    {
        public async Task<int> Create(Dish entity)
        {
            context.Dishes.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public Task Delete(Dish entity)
        {
            context.Dishes.Remove(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(Dish entity)
        {
            context.Dishes.Update(entity);
            return context.SaveChangesAsync();
        }
    }
}
