using MediatR;

using System.Text.Json.Serialization;

namespace Commands
{
    public class SendInvitationCommand : IRequest
    {
        [JsonIgnore]
        public string UserId { get; set; }
        [JsonIgnore]
        public string UserDisplayName { get; set; }
        [JsonIgnore]
        public string OrgId { get; set; }
        [JsonIgnore]
        public string OrgName { get; set; }

        public string InvitationEmail { get; set; }
        public string Name { get; set; }
        public string TeamId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
