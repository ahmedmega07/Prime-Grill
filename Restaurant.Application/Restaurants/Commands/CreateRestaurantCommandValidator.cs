using FluentValidation;

namespace Restaurant.Application.Restaurants.Commands
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {

        public CreateRestaurantCommandValidator()
        {
            RuleFor(r => r.Name)
               .Length(3, 50);

            RuleFor(r => r.Description).NotEmpty().WithMessage("Description is required.");

            RuleFor(c => c.Category).NotEmpty().WithMessage("Category is required.");

            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Invalid email address.");

            RuleFor(dto => dto.PostalCode).Matches(@"^\d{2}-\d{3}$").WithMessage("Invalid postal code format.");


        }
    }
}
