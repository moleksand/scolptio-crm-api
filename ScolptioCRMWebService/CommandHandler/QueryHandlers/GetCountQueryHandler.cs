
using Commands.Query;

using Domains.DBModels;

using MediatR;

using Services.Repository;

using System.Threading;
using System.Threading.Tasks;

namespace CommandHandlers.QueryHandlers
{
    public class GetCountQueryHandler : IRequestHandler<GetCountQuery, long>
    {

        private readonly IBaseRepository<Team> _baseRepositoryTeam;
        private readonly IBaseRepository<Income> _baseRepositoryIncome;
        private readonly IBaseRepository<UserOrganizationMapping> _baseRepositoryUser;
        private readonly IBaseRepository<Role> _baseRepositoryRole;
        private readonly IBaseRepository<Invitation> _baseRepositoryInvitation;
        private readonly IBaseRepository<Properties> _baseRepositoryProperties;
        private readonly IBaseRepository<DocumentTemplate> _baseRepositoryDocument;
        private readonly IBaseRepository<SalesWebsite> _baseRepositorySalesWebsite;
        private readonly IBaseRepository<Clients> _baseRepositoryClients;


        public GetCountQueryHandler(IBaseRepository<Team> baseRepositoryTeam
             , IBaseRepository<Role> baseRepositoryRole
            , IBaseRepository<Income> baseRepositoryIncome
             , IBaseRepository<UserOrganizationMapping> baseRepositoryUser
             , IBaseRepository<Invitation> baseRepositoryInvitation
             , IBaseRepository<Properties> baseRepositoryProperties
             , IBaseRepository<DocumentTemplate> baseRepositoryDocument
            , IBaseRepository<SalesWebsite> baseRepositorySalesWebsite,
            IBaseRepository<Clients> baseRepositoryClients
           )
        {
            _baseRepositoryRole = baseRepositoryRole;
            _baseRepositoryTeam = baseRepositoryTeam;
            _baseRepositoryIncome = baseRepositoryIncome;
            _baseRepositoryUser = baseRepositoryUser;
            _baseRepositoryInvitation = baseRepositoryInvitation;
            _baseRepositoryProperties = baseRepositoryProperties;
            _baseRepositoryDocument = baseRepositoryDocument;
            _baseRepositorySalesWebsite = baseRepositorySalesWebsite;
            _baseRepositoryClients = baseRepositoryClients;
        }


        public Task<long> Handle(GetCountQuery request, CancellationToken cancellationToken)
        {
            long count = 0;
            switch (request.EntityName.Name)
            {
                case "Team":
                    count = _baseRepositoryTeam.GetTotalCount(x => x.OrganizationId == request.OrganizationId);
                    break;
                case "Income":
                    count = _baseRepositoryIncome.GetTotalCount(x => x.OrgId == request.OrganizationId);
                    break;
                case "Role":
                    count = _baseRepositoryRole.GetTotalCount(x => x.OrganizationId == request.OrganizationId || x.OrganizationId == null);
                    break;
                case "User":
                    count = _baseRepositoryUser.GetTotalCount(x => x.OrganizationId == request.OrganizationId);
                    break;
                case "Invitation":
                    count = _baseRepositoryInvitation.GetTotalCount(x => x.OrgId == request.OrganizationId);
                    break;
                case "Organization":
                    count = _baseRepositoryUser.GetTotalCount(x => x.UserId == request.UserId);
                    break;
                case "Properties":
                    count = _baseRepositoryProperties.GetTotalCount(x => x.OrgId == request.OrganizationId);
                    break;
                case "DocumentTemplate":
                    count = _baseRepositoryDocument.GetTotalCount(x => x.OrgId == request.OrganizationId);
                    break;
                case "SalesWebsite":
                    count = _baseRepositorySalesWebsite.GetTotalCount(x => x.OrganizationId == request.OrganizationId);
                    break;
                case "Clients":
                    count = _baseRepositoryClients.GetTotalCount(x => x.OrgId == request.OrganizationId);
                    break;
                default:
                    break;
            }
            return Task.FromResult(count);
        }

    }
}
