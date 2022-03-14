
using Commands;

using FluentValidation;

namespace LandHubWebService.Validations
{
    public class GetOrgQueryValidator : AbstractValidator<GetOrgQuery>
    {
        public GetOrgQueryValidator()
        {
            RuleFor(x => x.OrgId).NotEmpty();
        }
    }
}
