﻿
using Commands;

using FluentValidation;

namespace LandHubWebService.Validations
{
    public class CreateNewOrgCommandValidator : AbstractValidator<CreateNewOrgCommand>
    {
        public CreateNewOrgCommandValidator()
        {
            RuleFor(x => x.OrgName).NotEmpty();
        }
    }
}
