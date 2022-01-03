using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestSamtel
{
    [TestClass]
    public class TestUsuarioReserva_ : BasePruebas
    {
       [TestMethod]
       public async Task ObetenerTodos()
        {
            // Preparacion
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            var mapper = ConfigurarAutoMapper();

            contexto.UsuarioReserva.Add(new HotelView)
        }
    }
}
