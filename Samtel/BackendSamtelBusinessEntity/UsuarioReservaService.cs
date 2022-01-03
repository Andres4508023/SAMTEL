using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BackendSamtelDomain.Models;
using Microsoft.EntityFrameworkCore;


namespace BackendSamtelBusinessEntity
{
   public class UsuarioReservaService : IUsuarioReservaService
    {
        private readonly SamtelContext _context;

        public UsuarioReservaService(SamtelContext context)
        {
            _context = context;
        }

        public List<UsuarioReservaView> GetUsuarioReserva(DateTime FechaEntrada, DateTime FechaSalida)
        {
            var UsuarioReserva = (from R in _context.Reserva
                                  join U in _context.Usuario on R.IdUsuario equals U.IdUsuario
                                  join H in _context.Hotel on R.IdHotel equals H.IdHotel
                                  where R.EstadoReserva == "Activo" && R.FechaReserva >= FechaEntrada && R.FechaReserva <= FechaSalida

                                  select new UsuarioReservaView
                                  {
                                      TipoIdentificacion = U.TipoIdentificacion,
                                      Identificacion = U.NumeroIdentificacion,
                                      Nombres = U.Nombres,
                                      Apellidos = U.Apellidos,
                                      Email = U.Email,
                                      HotelView = H.NombreHotel,
                                      FechaReserva = R.FechaReserva
                                  });

            return UsuarioReserva.ToList();
        }

        public bool AddUsuarioReserva(UsuarioReservaView model)
        {
            //using (var transcation = _context.Database.BeginTransaction())
            //{
                try
                {
                    var usu = new Usuario
                    {
                        TipoIdentificacion = model.TipoIdentificacion,
                        NumeroIdentificacion = model.Identificacion,
                        Nombres = model.Nombres,
                        Apellidos = model.Apellidos,
                        Email = model.Email,
                        TelCelular = model.TelCelular
                    };
                    
                    _context.Usuario.Add(usu);
                    _context.SaveChanges();
                 
                    var IdUsuario_ = (from U in _context.Usuario where U.NumeroIdentificacion == model.Identificacion select U.IdUsuario).ToList();

                    var Res = new Reserva
                    {
                        IdUsuario = IdUsuario_.First(),                    
                        IdHotel = Convert.ToInt32(model.HotelView),
                        Habitacion = model.Habitacion,
                        FechaReserva = DateTime.Now,
                        FechaEntrada = model.FechaEntrada,
                        FechaSalida = model.FechaSalida,
                        EstadoReserva = "Activo"
                    };
                    _context.Reserva.Add(Res);
                    _context.SaveChanges();
                    //transcation.Commit();
                    
                }
                   
                catch (Exception ex)
                {
                    //transcation.Rollback();
                    //return false;
                }
            return true;
            //}
        }

        public bool UpdateEstadoReserva(UpdateReservaHotelView model)
        {
            try
            {
                var update = (from R in _context.Reserva
                              join U in _context.Usuario on R.IdUsuario equals U.IdUsuario
                              where U.NumeroIdentificacion == model.Identificacion
                              select R).FirstOrDefault();

                update.EstadoReserva = "Inactivo";
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Hotel> GetHotel()
        {
            var List = (from p in _context.Hotel
                                select new Hotel
                                {
                                    IdHotel = p.IdHotel,
                                    NombreHotel = p.NombreHotel,
                                    Pais = p.Pais,
                                    DireccionHotel = p.DireccionHotel,
                                    Estado = p.Estado,
                                    NumeroHabitaciones = p.NumeroHabitaciones
                                }).ToList();
            
            return List;
        }
    }
}
