using MediatR;

using System;

namespace Commands.Query
{
    public class GetCountQuery : IRequest<long>
    {
        public string OrganizationId { get; set; }
        public string UserId { get; set; }
        public Type EntityName { get; set; }
    }
}
