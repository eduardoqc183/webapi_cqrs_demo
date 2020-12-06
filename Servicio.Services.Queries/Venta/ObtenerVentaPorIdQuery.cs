using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Servicio.Persistence.Database.Models;

namespace Servicio.Services.Queries.Venta
{
    public class ObtenerVentaPorIdQuery : IRequest<ventaDto>
    {
        [Range(0, int.MaxValue)]
        [Required]
        public int VentaId { get; }

        public ObtenerVentaPorIdQuery(int id)
        {
            VentaId = id;
        }

        public class ObtenerVentaPorIdHandler : IRequestHandler<ObtenerVentaPorIdQuery, ventaDto>
        {
            private readonly CompanyContext _context;

            public ObtenerVentaPorIdHandler(CompanyContext context)
            {
                _context = context;
            }

            public async Task<ventaDto> Handle(ObtenerVentaPorIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var data = await (from v in _context.venta
                                      join c in _context.cliente on v.clienteid.Value equals c.clienteid into cJoin
                                      from c in cJoin.DefaultIfEmpty()
                                      where v.ventaid == request.VentaId
                                      select new ventaDto
                                      {
                                          clienteid = v.clienteid,
                                          fechaemision = v.fechaemision,
                                          ventaid = v.ventaid,
                                          ClienteDireccion = c.direccionjuridica,
                                          ClienteNombre = c.nombrerazonsocial,
                                          ClienteNroDoc = c.nrodocidentidad,
                                          baseimponible = v.baseimponible,
                                          correlativo = v.correlativo,
                                          documentoid = v.documentoid,
                                          fecharegistro = v.fecharegistro,
                                          igv = v.igv,
                                          serie = v.serie,
                                          total = v.total
                                      })
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if (data == null) return null;

                    data.Detalles = await ObtenerVentaDetalleAsync(request.VentaId);

                    return data;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            private async Task<List<ventadetalleDto>> ObtenerVentaDetalleAsync(int idventa)
            {
                try
                {
                    return await (from vd in _context.ventadetalle
                                  join p in _context.producto on vd.productoid equals p.productoid into pJoin
                                  from p in pJoin.DefaultIfEmpty()
                                  where vd.ventaid.Equals(idventa)
                                  select new ventadetalleDto
                                  {
                                      ventaid = vd.ventaid,
                                      igv = vd.igv,
                                      productoid = vd.productoid,
                                      cantidad = vd.cantidad,
                                      precio = vd.precio,
                                      valor = vd.valor,
                                      valorunitario = vd.valorunitario,
                                      ventadetalleid = vd.ventadetalleid,
                                      CodProducto = p.codproducto,
                                      DescripcionProducto = p.nombreproducto
                                  })
                        .ToListAsync();
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
