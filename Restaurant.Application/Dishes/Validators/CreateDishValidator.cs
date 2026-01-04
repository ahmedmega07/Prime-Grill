using FluentValidation;
using Restaurant.Application.Dishes.Commands.CreateDish;

namespace Restaurant.Application.Dishes.Validators
{
    public class CreateDishValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishValidator()
        {
            RuleFor(dish => dish.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be greater than or equal to 0.");




        }
    }
}
