namespace Domains.DBModels
{
    public class Invitation : BaseEntity
    {
        public string SenderId { get; set; }
        public string SenderEmail { get; set; }
        public string OrgId { get; set; }
        public string InvitedUserEmail { get; set; }
        public string TeamId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
