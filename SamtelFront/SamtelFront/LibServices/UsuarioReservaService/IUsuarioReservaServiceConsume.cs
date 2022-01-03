using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace LibServices.UsuarioReservaService
{
    public interface IUsuarioReservaServiceConsume
    {
        Task<List<HotelView>> GetHotelList();
        Task<List<UsuarioReservaView>> GetUsuarioReservaList(DateTime FechaEntrada, DateTime FechaSalida);
        Task<bool> SaveUsuarioReserva(UsuarioReservaView model);
        Task<bool> UpdateUsuarioReserva(UpdateReservaHotelView model);
    }
}
