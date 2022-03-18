﻿
using Commands;
using Commands.Query;

using Domains.DBModels;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace ScolptioCRMWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationController : BaseController
    {
        private readonly IMediator _mediator;
        public InvitationController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> GetAll([FromBody] GetAllInvitationQuery query)
        {
            query.OrgId = SecurityContext.OrgId;
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult> GetTotalCount()
        {
            var getCountQuery = new GetCountQuery()
            {
                OrganizationId = SecurityContext.OrgId,
                EntityName = typeof(Invitation)
            };
            var result = await _mediator.Send(getCountQuery);
            return Ok(result);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult> DeleteInvitation([FromBody] DeleteInvitationCommand deleteInvitationCommand)
        {
            deleteInvitationCommand.OrganizationId = SecurityContext.OrgId;
            await _mediator.Send(deleteInvitationCommand);
            return Ok();
        }

    }
}
