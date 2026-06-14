using FluentValidation;
using UnitConversionApi.Models;

namespace UnitConversionApi.Validators
{
    public class ConversionRequestValidator
    : AbstractValidator<ConversionRequest>
    {
        public ConversionRequestValidator()
        {
            RuleFor(x => x.FromUnit)
                .NotEmpty();

            RuleFor(x => x.ToUnit)
                .NotEmpty();

            RuleFor(x => x.Value)
                .NotNull();
        }
    }
}
