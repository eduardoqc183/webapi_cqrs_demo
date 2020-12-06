using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Servicio.Common.Mapping;
using Servicio.Persistence.Database.Models;
using Servicio.Services.Commands.Requests.Venta;

namespace Servicio.Services.Commands.Handlers.Venta
{
    public class InsertarClienteEventHandler : IRequestHandler<InsertarClienteCommand, int>
    {
        private readonly CompanyContext _context;

        public InsertarClienteEventHandler(CompanyContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(InsertarClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entidad = request.MapTo<cliente>();
                entidad.fecharegistro = DateTime.Now;

                await _context.cliente.AddAsync(entidad, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return entidad.clienteid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
