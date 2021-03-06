using System;
using System.Collections.Generic;

namespace BackendSamtelDomain.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int? TelCelular { get; set; }

        public ICollection<Reserva> Reserva { get; set; }
    }
}
