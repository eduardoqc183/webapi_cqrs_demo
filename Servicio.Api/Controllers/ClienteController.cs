using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Servicio.Services.Commands.Requests.Venta;
using Servicio.Services.Queries;
using Servicio.Services.Queries.Venta;

namespace Servicio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IConfiguration configuration, IMediator mediator, ILogger<ClienteController> logger)
        {
            _configuration = configuration;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("ObtenerClientePorId/{id:int}")]
        [ProducesResponseType(typeof(clienteDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> ObtenerClientePorId(int id)
        {
            try
            {
                _logger.LogInformation($"Call to Ventas/ObtenerClientePorId: {id}");

                var dto = await _mediator.Send(new ObtenerClientePorIdQuery(id));
                if (dto == null) return NotFound(new ProblemDetails { Detail = "No se encontró el cliente con id: " + id });

                return Ok(dto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost("InsertarCliente")]
        [ProducesResponseType(typeof(clienteDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> InsertarCliente(InsertarClienteCommand command)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                _logger.LogInformation($"Call to Ventas/InsertarCliente: {JsonConvert.SerializeObject(command)}");

                var id = await _mediator.Send(command);
                var dto = await _mediator.Send(new ObtenerClientePorIdQuery(id));

                return Created(nameof(ObtenerClientePorId), dto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
