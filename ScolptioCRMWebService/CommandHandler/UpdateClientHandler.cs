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
    public class UpdateClientHandler : AsyncRequestHandler<UpdateClientsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Clients> _baseRepositoryClients;

        public UpdateClientHandler(IMapper mapper, IBaseRepository<Clients> baseRepositoryClients)
        {
            _mapper = mapper;
            _baseRepositoryClients = baseRepositoryClients;
        }

        protected override async Task Handle(UpdateClientsCommand request, CancellationToken cancellationToken)
        {
            var client = await _baseRepositoryClients.GetByIdAsync(request.Id);

            if (client == null)
                return;

            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.Website = request.Website;
            client.CompanyAdress = request.CompanyAdress;
            client.Logo = request.Logo;
            client.Email = request.Email;
            client.PhoneNumber = request.PhoneNumber;
            client.CompanyName = request.CompanyName;
            await _baseRepositoryClients.UpdateAsync(client);
        }
    }
}
