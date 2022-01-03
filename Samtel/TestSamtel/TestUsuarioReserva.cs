using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BackendSamtelBusinessEntity;
using BackendSamtelDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestSamtel
{
    [TestClass]
    public class TestUsuarioReserva
    {
        [TestMethod]
        public void GetUsuarioReserva()
        {
            try
            {
                int IdHotel = 1;
                var Hotel_ = new SpAsyncEnumerableQueryable<Hotel>(
                    new Hotel
                    {      
                        IdHotel = 3,
                        NombreHotel = "Hilton",
                        Pais = "Colombia",
                        DireccionHotel = "Av 2",
                        Estado = "Activo",
                        NumeroHabitaciones = 3
                    });
                var parameterContextOptions = new DbContextOptionsBuilder<SamtelContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
                SamtelContext parameterContext = new SamtelContext(parameterContextOptions);
                parameterContext.Hotel = parameterContext.Hotel.MockFromSql(Hotel_);

                UsuarioReservaService _PropertyService = new UsuarioReservaService(parameterContext);
                var result = _PropertyService.GetHotel();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
