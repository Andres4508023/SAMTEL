using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class HotelView
    {
        public int IdHotel { get; set; }
        public string NombreHotel { get; set; }
        public string Pais { get; set; }
        public string DireccionHotel { get; set; }
        public string Estado { get; set; }
        public int? NumeroHabitaciones { get; set; }
    }
}
