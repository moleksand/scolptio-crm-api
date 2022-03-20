using Commands;
using Commands.Query;
using Domains.DBModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScolptioCRMWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : BaseController
    {
        private readonly IMediator _mediator;
        public ClientsController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> GetAll([FromBody] GetAllClientsQuery GetAllClientsQuery)
        {
            GetAllClientsQuery.OrgId = SecurityContext.OrgId;
            var result = await _mediator.Send(GetAllClientsQuery);
            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult> GetTotalCount()
        {
            var getCountQuery = new GetCountQuery()
            {
                OrganizationId = SecurityContext.OrgId,
                EntityName = typeof(Clients)
            };
            var result = await _mediator.Send(getCountQuery);
            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult> GetById(string incomeId)
        {
            var getIncomeQuery = new GetIncomeQuery
            {
                OrgId = SecurityContext.OrgId,
                IncomeId = incomeId
            };

            var result = await _mediator.Send(getIncomeQuery);
            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Add([FromBody] CreateClientsCommand CreateClientsCommand)
        {
            CreateClientsCommand.OrgId = SecurityContext.OrgId;
            CreateClientsCommand.CreatedDate = DateTime.Now;
            await _mediator.Send(CreateClientsCommand);
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] UpdateClientsCommand UpdateClientsCommand)
        {
            await _mediator.Send(UpdateClientsCommand);
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Delete([FromBody] DeleteClientsCommand DeleteClientsCommand)
        {
            await _mediator.Send(DeleteClientsCommand);
            return Ok();
        }
    }
}
