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
    public class DeleteClientsCommandHandler : IRequestHandler<DeleteClientsCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Clients> _baseRepositoryClients;

        public DeleteClientsCommandHandler(IMapper mapper, IBaseRepository<Clients> baseRepositoryClients)
        {
            _mapper = mapper;
            _baseRepositoryClients = baseRepositoryClients;
        }

        public async Task<bool> Handle(DeleteClientsCommand request, CancellationToken cancellationToken)
        {
            await _baseRepositoryClients.Delete(request.Id);
            return true;
        }

    }
}
