using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Servicio.Common.Mapping;
using Servicio.Persistence.Database.Models;
using Servicio.Services.Commands.Requests.Venta;

namespace Servicio.Services.Commands.Handlers.Venta
{
    public class InsertarVentaEventHandler : IRequestHandler<InsertarVentaCommand, int>
    {
        private readonly CompanyContext _context;

        public InsertarVentaEventHandler(CompanyContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(InsertarVentaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vta = request.MapTo<venta>();
                vta.fecharegistro = DateTime.Now;
                
                var detalles = request.Detalles.Select(s => s.MapTo<ventadetalle>());

                foreach (var d in detalles)
                    vta.ventadetalle.Add(d);

                await _context.venta.AddAsync(vta, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return vta.ventaid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
