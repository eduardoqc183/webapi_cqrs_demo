using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Servicio.Persistence.Database.Extensions;
using Servicio.Persistence.Database.Models;
using Servicio.Persistence.Database.Utils;
using Servicio.Services.Queries.Responses.Custom;

namespace Servicio.Services.Queries.Venta
{
    public class ObtenerVentasPorFiltroQuery : IRequest<DataCollection<ConsultaVenta>>
    {
        [Required]
        public int Page { get;}
        [Required]
        public int Take { get; }
        [Required]
        public DateTimeOffset F1 { get;}
        [Required]
        public DateTimeOffset F2 { get; }
        public int? IdCliente { get; }

        public ObtenerVentasPorFiltroQuery(int page, int take, DateTimeOffset f1, DateTimeOffset f2, int? idcliente)
        {
            Page = page;
            Take = take;
            F1 = f1;
            F2 = f2;
            IdCliente = idcliente;
        }
        public class ObtenerVentasPorFiltroHandler : IRequestHandler<ObtenerVentasPorFiltroQuery, DataCollection<ConsultaVenta>>
        {
            private readonly CompanyContext _context;

            public ObtenerVentasPorFiltroHandler(CompanyContext context)
            {
                _context = context;
            }

            public async Task<DataCollection<ConsultaVenta>> Handle(ObtenerVentasPorFiltroQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = from v in _context.venta
                        join c in _context.cliente on v.clienteid.Value equals c.clienteid into cJoin
                        from c in cJoin.DefaultIfEmpty()
                        join d in _context.documento on v.documentoid equals d.documentoid into dJoin
                        from d in dJoin.DefaultIfEmpty()
                        where v.fecharegistro >= request.F1 && v.fecharegistro <= request.F2 &&
                              (!request.IdCliente.HasValue || v.clienteid.Value.Equals(request.IdCliente.Value))
                        select new ConsultaVenta
                        {
                            Cliente = c.nombrerazonsocial,
                            Correlativo = v.correlativo,
                            FechaEmision = v.fechaemision,
                            NroDocCliente = c.nrodocidentidad,
                            Serie = v.serie,
                            TipoDoc = d.siglas
                        };

                    var result = await query.GetPagedAsync(request.Page, request.Take);

                    return result;
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
