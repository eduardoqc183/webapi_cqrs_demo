using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Servicio.Common.Mapping;
using Servicio.Persistence.Database.Models;

namespace Servicio.Services.Queries.Venta
{
    public class ObtenerClientePorIdQuery : IRequest<clienteDto>
    {
        public int ClienteId { get; }

        public ObtenerClientePorIdQuery(int id)
        {
            ClienteId = id;
        }

        public class ObtenerClientePorIdEventHandler : IRequestHandler<ObtenerClientePorIdQuery, clienteDto>
        {
            private readonly CompanyContext _context;

            public ObtenerClientePorIdEventHandler(CompanyContext context)
            {
                _context = context;
            }

            public async Task<clienteDto> Handle(ObtenerClientePorIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var entidad = await _context.cliente.FindAsync(request.ClienteId);

                    return entidad?.MapTo<clienteDto>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
