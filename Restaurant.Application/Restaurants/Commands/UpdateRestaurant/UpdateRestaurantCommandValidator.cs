using FluentValidation;

namespace Restaurant.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(r => r.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(r => r.Name)
                .Length(3, 50).WithMessage("Name must be between 3 and 50 characters.");

            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(r => r.Category)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(r => r.ContactEmail)
                .EmailAddress().WithMessage("Invalid email address.")
                .When(r => !string.IsNullOrEmpty(r.ContactEmail));

            RuleFor(r => r.PostalCode)
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Invalid postal code format.")
                .When(r => !string.IsNullOrEmpty(r.PostalCode));
        }
    }
}