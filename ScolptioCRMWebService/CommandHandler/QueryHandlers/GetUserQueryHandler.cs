using AutoMapper;

using Commands;

using Domains.DBModels;
using Domains.Dtos;

using MediatR;

using Services.Repository;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CommandHandlers.QueryHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserForUi>
    {

        private readonly IBaseRepository<User> _userBaseRepository;
        private readonly IBaseRepository<UserRoleMapping> _userRoleMappingBaseRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IBaseRepository<User> userBaseRepository
            , IBaseRepository<UserRoleMapping> userRoleMappingBaseRepository
            , IMapper mapper)
        {
            _userBaseRepository = userBaseRepository;
            _userRoleMappingBaseRepository = userRoleMappingBaseRepository;
            _mapper = mapper;
        }

        public async Task<UserForUi> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userBaseRepository.GetByIdAsync(request.UserId);
            if (request.OrgId != null)
            {
                var rolesMapping = await _userRoleMappingBaseRepository.GetAllAsync(x =>
                    x.OrganizationId == request.OrgId && x.UserId == request.UserId);
                List<string> rolesId = new List<string>();
                foreach (UserRoleMapping rolePermissionMapping in rolesMapping)
                {
                    rolesId.Add(rolePermissionMapping.Id);
                }

                user.Roles = rolesId;
            }

            var uiUser = _mapper.Map<User, UserForUi>(user);
            return uiUser;
        }

    }
}
