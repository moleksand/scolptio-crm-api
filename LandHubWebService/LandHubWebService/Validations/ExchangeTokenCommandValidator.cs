
using Commands;

using FluentValidation;

namespace LandHubWebService.Validations
{
    public class ExchangeTokenCommandValidator : AbstractValidator<ExchangeTokenCommand>
    {
        public ExchangeTokenCommandValidator()
        {
            RuleFor(x => x.OrgId).NotEmpty();
        }
    }
}
