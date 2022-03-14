using MediatR;

using System.Collections.Generic;

namespace Commands
{
    public class UpdateTeamCommand : IRequest
    {
        public string Id { get; set; }
        public string TeamName { get; set; }
        public string OrganizationId { get; set; }
        public List<string> Members { get; set; }
        public string Role { get; set; }

        public UpdateTeamCommand()
        {
            Members = new List<string>();
        }
    }
}
