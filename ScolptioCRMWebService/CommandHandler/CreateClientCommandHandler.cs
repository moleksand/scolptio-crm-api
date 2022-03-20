using AutoMapper;
using Commands;
using Domains.DBModels;
using MediatR;
using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandHandlers
{
    public class CreateClientCommandHandler : AsyncRequestHandler<CreateClientsCommand>
    {
        private readonly IMapper _mapper;
        private IBaseRepository<Clients> _baseRepositoryClients;

        public CreateClientCommandHandler(IMapper mapper, IBaseRepository<Clients> baseRepositoryClients)
        {
            _mapper = mapper;
            _baseRepositoryClients = baseRepositoryClients;
        }

        protected override async Task Handle(CreateClientsCommand request, CancellationToken cancellationToken)
        {
            var client = new Clients()
            {
                OrgId = request.OrgId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Website = request.Website,
                CompanyAdress = request.CompanyAdress,
                Logo = request.Logo,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CompanyName = request.CompanyName
            };
            client.Id = Guid.NewGuid().ToString();
            await _baseRepositoryClients.Create(client);
        }
    }
}
