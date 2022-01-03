using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using LibServices.UsuarioReservaService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SamtelFront.Controllers
{
    public class UsuarioReservaConsumeController : Controller
    {
        private readonly IUsuarioReservaServiceConsume _usuarioReservaServiceConsume;

        public UsuarioReservaConsumeController(IUsuarioReservaServiceConsume usuarioReservaServiceConsume)
        {
            _usuarioReservaServiceConsume = usuarioReservaServiceConsume;
        }

        

        public async Task<IActionResult> GetUsuarioReservaList(DateTime FechaEntrada, DateTime FechaSalida)
        {
            var FechaEntradaF = FechaEntrada.ToString("yyyy-MM-dd");
            var FechaSalidaF = FechaSalida.ToString("yyyy-MM-dd");

            if (FechaEntradaF == "0001-01-01" || FechaSalidaF == "0001-01-01")
            {
                var myDate = DateTime.Now;
                var oldDate = myDate.AddYears(-1);

                var list = await _usuarioReservaServiceConsume.GetUsuarioReservaList(oldDate, DateTime.Now);
                ViewBag.List = list;
            }
            else
            {
                var lista = await _usuarioReservaServiceConsume.GetUsuarioReservaList(FechaEntrada, FechaSalida);
                ViewBag.List = lista;
            }
            return View();
        }


        public async Task<IActionResult> CreateUsuarioReserva()
        {
            List<HotelView> listHotel = await _usuarioReservaServiceConsume.GetHotelList();                
            ViewBag.listHotel = new SelectList(listHotel, "IdHotel", "NombreHotel");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuarioReserva(UsuarioReservaView model)
        {
            bool response = await _usuarioReservaServiceConsume.SaveUsuarioReserva(model);
            return RedirectToAction("GetUsuarioReservaList");
        }

        public async Task<IActionResult> EditUsuarioReserva(string id)
        {
            try
            {
                var model = new UpdateReservaHotelView();
                model.Identificacion = id;
                bool response = await _usuarioReservaServiceConsume.UpdateUsuarioReserva(model);

                return RedirectToAction("GetUsuarioReservaList");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
