using System;
using System.Collections.Generic;

namespace BackendSamtelDomain.Models
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdHotel { get; set; }
        public int? Habitacion { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string EstadoReserva { get; set; }

        public Hotel IdHotelNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
