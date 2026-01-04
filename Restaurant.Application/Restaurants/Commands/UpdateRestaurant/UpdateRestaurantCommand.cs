using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand : IRequest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public string Category { get; set; } = default!;

        [EmailAddress]
        public string? ContactEmail { get; set; }

        public string? ContactNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }

        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Invalid postal code format.")]
        public string? PostalCode { get; set; }

        public bool HasDelivery { get; set; }
    }
}
