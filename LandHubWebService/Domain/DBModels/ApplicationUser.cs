using AspNetCore.Identity.MongoDbCore.Models;

using MongoDbGenericRepository.Attributes;

using System;
namespace Domains.DBModels
{
    [CollectionName("User")]
    public class ApplicationUser : MongoIdentityUser<string>
    {

        public ApplicationUser() : base()
        {

        }

        public ApplicationUser(string userName, string email) : base(userName, email)
        {
        }
        public ApplicationUser(string userName, string email, string displayName) : base(userName, email)
        {
            this.DisplayName = displayName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportNumber { get; set; }
        public string Occupation { get; set; }
        public string ProfileImage { get; set; }

        public string Status { get; set; }
        public string DisplayName
        {
            get { return $"{FirstName} {LastName}"; }
            set { }
        }

        public string Address { get; set; }
        //  public string OrganizationId { get; set; }
        // public string OrganizationName { get; set; }
        public string CountryName { get; set; }

        public DateTime DOB { get; set; }
        public string Salutation { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Signature { get; set; }
    }
}
