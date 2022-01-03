using System;
using System.Collections.Generic;
using System.Text;
using BackendSamtelDomain.Models;

namespace BackendSamtelBusinessEntity
{
   public interface IUsuarioReservaService
    {
        List<UsuarioReservaView> GetUsuarioReserva(DateTime FechaEntrada, DateTime FechaSalida);
        IEnumerable<Hotel> GetHotel();
        bool AddUsuarioReserva(UsuarioReservaView model);
        bool UpdateEstadoReserva(UpdateReservaHotelView model);
    }
}
