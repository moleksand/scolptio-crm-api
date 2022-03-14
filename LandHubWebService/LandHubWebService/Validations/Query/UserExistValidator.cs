
using Commands;

using FluentValidation;

namespace LandHubWebService.Validations
{
    public class UserExistQueryValidator : AbstractValidator<UserExistQuery>
    {
        public UserExistQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
        }
    }
}
