using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Commands
{
    public class CreateClientsCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        [JsonIgnore]
        public string OrgId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
