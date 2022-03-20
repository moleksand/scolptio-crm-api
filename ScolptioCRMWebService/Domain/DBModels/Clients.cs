using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.DBModels
{
    public class Clients : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public string OrgId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
