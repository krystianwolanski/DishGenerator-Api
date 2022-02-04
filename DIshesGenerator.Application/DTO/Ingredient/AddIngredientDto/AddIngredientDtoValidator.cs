using FluentValidation;

namespace DishesGenerator.Application.DTO.Ingredient.AddIngredientDto
{
    public class AddIngredientDtoValidator : AbstractValidator<AddIngredientDto>
    {
        public AddIngredientDtoValidator()
        {
            RuleFor(i => i.Grams)
                .GreaterThan(0);

            RuleFor(i => i.IngredientName)
                .MaximumLength(50);
        }   
    }
}
