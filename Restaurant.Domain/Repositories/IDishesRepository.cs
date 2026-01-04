using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories
{
    public interface IDishesRepository
    {
        Task<int> Create(Dish entity);

        Task Delete(Dish entity);

        Task Update(Dish entity);
    }
}

