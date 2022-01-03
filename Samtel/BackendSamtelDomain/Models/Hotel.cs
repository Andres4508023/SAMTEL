using System;
using System.Collections.Generic;

namespace BackendSamtelDomain.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int IdHotel { get; set; }
        public string NombreHotel { get; set; }
        public string Pais { get; set; }
        public string DireccionHotel { get; set; }
        public string Estado { get; set; }
        public int? NumeroHabitaciones { get; set; }

        public ICollection<Reserva> Reserva { get; set; }
    }
}
