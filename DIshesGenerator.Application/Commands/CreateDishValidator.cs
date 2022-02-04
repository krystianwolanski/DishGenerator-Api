using DishesGenerator.Application.DTO.Ingredient.AddIngredientDto;
using FluentValidation;

namespace DishesGenerator.Application.Commands
{
    public class CreateDishValidator : AbstractValidator<CreateDish>
    {
        public CreateDishValidator()
        {
            RuleFor(d => d.Portions)
                .GreaterThan(0u);

            RuleFor(d => d.Name)
                .MaximumLength(50);

            RuleForEach(d => d.Ingredients)
                .SetValidator(new AddIngredientDtoValidator());
        }        
    }
}
