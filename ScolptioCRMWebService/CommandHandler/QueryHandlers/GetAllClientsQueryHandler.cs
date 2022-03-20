using AutoMapper;
using Commands.Query;
using Domains.DBModels;
using MediatR;
using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandHandlers.QueryHandlers
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<Clients>>
    {

        private readonly IBaseRepository<Clients> _baseRepositoryClients;
        private readonly IMapper _mapper;


        public GetAllClientsQueryHandler(IMapper mapper, IBaseRepository<Clients> baseRepositoryClients)
        {
            _mapper = mapper;
            _baseRepositoryClients = baseRepositoryClients;
        }

        public async Task<List<Clients>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var ClientList = new List<Clients>();
            var clientList = await _baseRepositoryClients.GetAllWithPagingAsync(x => x.OrgId == request.OrgId, request.PageNumber, request.PageSize);
            if(request.SearchKey!=null)

            clientList = clientList.Where(m => m.FirstName.Contains(request.SearchKey)).ToList();

            return clientList.ToList();
        }
    }
}
