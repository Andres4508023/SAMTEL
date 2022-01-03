using System;

namespace Domain
{
    public class UsuarioReservaView
    {
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string HotelView { get; set; }
        public int TelCelular { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string EstadoReserva { get; set; }
        public int Habitacion { get; set; }


    }
}
