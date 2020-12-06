using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Servicio.Services.Commands.Requests;
using Servicio.Services.Commands.Requests.Venta;
using Servicio.Services.Queries;
using Servicio.Services.Queries.Venta;

namespace Servicio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<VentasController> _logger;
        private readonly IMediator _mediator;

        public VentasController(IConfiguration configuration, ILogger<VentasController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("InsertarVenta")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> InsertarVenta(InsertarVentaCommand command)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                _logger.LogInformation($"Call to Ventas/InsertarVenta: {JsonConvert.SerializeObject(command)}");

                var i = await _mediator.Send(command);

                return Created("ObtenerVentaPorId", new { id = i });
            }
            catch (Exception e) 
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet("ObtenerVentaPorId/{id:int}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> ObtenerVentaPorId(int id)
        {
            try
            {
                if (id <= 0) return BadRequest(new ProblemDetails { Detail = "Id no válido" });

                var req = new ObtenerVentaPorIdQuery(id);

                _logger.LogInformation($"Call to Ventas/ObtenerVentaPorId: {id}");

                var dto = await _mediator.Send(req);
                if (dto == null)
                    return NotFound(new ProblemDetails { Detail = "No existe la venta con id: " + id });

                return Ok(dto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
