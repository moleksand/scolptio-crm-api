
using Commands;

using FluentValidation;

namespace LandHubWebService.Validations
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(x => x.OrganizationId).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
