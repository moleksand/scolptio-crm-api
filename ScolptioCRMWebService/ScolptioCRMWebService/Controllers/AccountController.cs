
using Commands;
using Commands.Query;

using Domains.DBModels;
using Domains.Dtos;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ScolptioCRMWebApi.ApplicationContext;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScolptioCRMWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> SaveUser([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> UpdateUserInformation([FromBody] UserUpdateCommand command)
        {
            command.Id = SecurityContext.UserId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<UserForUi>> GetUserInformation()
        {
            var getUserQuery = new GetUserQuery { OrgId = SecurityContext.OrgId, UserId = SecurityContext.UserId };
            var response = await _mediator.Send(getUserQuery);
            return Ok(response);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<UserForUi>> GetUserInformationByUserId(string userId)
        {
            var getUserQuery = new GetUserQuery { UserId = userId };
            var response = await _mediator.Send(getUserQuery);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult<List<UserForUi>>> GetUsersInformationByOrg([FromBody] GetAllUserByOrgQuery getUserQuery)
        {
            getUserQuery.OrgId = SecurityContext.OrgId;
            var response = await _mediator.Send(getUserQuery);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult<Organization>> GetUserOrganization([FromBody] GetUserSpecificOrgQuery getUserQuery)
        {
            getUserQuery.UserId = SecurityContext.UserId;
            var response = await _mediator.Send(getUserQuery);
            return Ok(response);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult> GetUserOrganizationTotalCount()
        {
            var getCountQuery = new GetCountQuery()
            {
                OrganizationId = SecurityContext.OrgId,
                UserId = SecurityContext.UserId,
                EntityName = typeof(Organization)
            };
            var result = await _mediator.Send(getCountQuery);
            return Ok(result);
        }


        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult> GetUserTotalCount()
        {
            var getCountQuery = new GetCountQuery()
            {
                OrganizationId = SecurityContext.OrgId,
                EntityName = typeof(User)
            };
            var result = await _mediator.Send(getCountQuery);
            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult<UserForUi>> TokenExchange([FromBody] ExchangeTokenCommand exchangeTokenCommand)
        {
            exchangeTokenCommand.UserName = SecurityContext.UserName;
            var response = await _mediator.Send(exchangeTokenCommand);
            return Ok(response);
        }
        /*
        [HttpPut("[action]")]
        [Authorize]
        public ActionResult UpdateUserRole([FromBody] UpdateUserRoleCommand command)
        {
            _mediator.Send(command);
            return Ok();
        }
        */

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult<UserForUi>> RemoveUserFromOrganization([FromBody] RemoveUserCommand removeUserCommand)
        {
            removeUserCommand.OrgId = SecurityContext.OrgId;
            if (removeUserCommand.UserId != SecurityContext.UserId)
            {
                await _mediator.Send(removeUserCommand);
            }

            return Ok();
        }



        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> AcceptInvitation([FromBody] AcceptInvitationCommand command)
        {
            command.UserName = SecurityContext.UserName;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> InviteUserAsync([FromBody] SendInvitationCommand command)
        {
            command.UserId = SecurityContext.UserId;
            command.UserDisplayName = SecurityContext.DisplayName;
            command.OrgId = SecurityContext.OrgId;
            command.OrgName = SecurityContext.OrgName;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> ResetPasswordAsync([FromBody] ChangePasswordCommand changePasswordCommand)
        {
            changePasswordCommand.Email = SecurityContext.Email;
            var result = await _mediator.Send(changePasswordCommand);
            return Ok(result);
        }
    }
}
