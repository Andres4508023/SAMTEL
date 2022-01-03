using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendSamtelDomain.Models;
using BackendSamtelBusinessEntity;

namespace Samtel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioReservaController : ControllerBase
    {
        private readonly IUsuarioReservaService _UsuarioReservaService;

        public UsuarioReservaController(IUsuarioReservaService UsuarioReservaService)
        {
            _UsuarioReservaService = UsuarioReservaService;
        }

        [HttpGet("{FechaEntrada}/{FechaSalida}")]
        public ActionResult<IEnumerable<UsuarioReservaView>> GeUsuarioReservaList(DateTime FechaEntrada, DateTime FechaSalida)
        {
        
            var result = _UsuarioReservaService.GetUsuarioReserva(FechaEntrada, FechaSalida);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetHotelList")]
        public ActionResult<IEnumerable<Hotel>> GePropertyList()
        {
            var result = _UsuarioReservaService.GetHotel();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddUsuarioReserva")]
        public ActionResult<bool> CreateUsuarioReserva(UsuarioReservaView model)
        {
            var response = _UsuarioReservaService.AddUsuarioReserva(model);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpPut]
        [Route("UpdateUsuarioReserva")]
        public ActionResult<bool> UpdateUsuarioReserva(UpdateReservaHotelView model)
        {
            var response = _UsuarioReservaService.UpdateEstadoReserva(model);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }
    }
}