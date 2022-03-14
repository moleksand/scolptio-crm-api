
using Commands;
using Commands.Query;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace PropertyHatchWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : BaseController
    {
        private readonly IMediator _mediator;
        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> GetFiles([FromBody] GetFilesQuery filesQuery)
        {
            filesQuery.OrgId = this.SecurityContext.OrgId;

            var result = await _mediator.Send(filesQuery);
            return Ok(result);
        }


        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Add([FromBody] CreateFileCommand createFileCommand)
        {
            createFileCommand.OrgId = SecurityContext.OrgId;
            createFileCommand.UploadedBy = SecurityContext.UserId;
            var id = await _mediator.Send(createFileCommand);
            return Ok(id);
        }


        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Delete([FromBody] DeleteFileCommand deleteFileCommand)
        {
            await _mediator.Send(deleteFileCommand);
            return Ok();
        }

    }
}
