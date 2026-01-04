

using Restaurant.Application.Dishes.Dtos;

namespace Restaurant.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {


        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public bool HasDelivery { get; set; }
        public List<DishDto> Dishes { get; set; } = new();


    }
}
