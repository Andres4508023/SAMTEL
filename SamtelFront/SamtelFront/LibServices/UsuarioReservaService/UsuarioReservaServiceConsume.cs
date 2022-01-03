using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LibServices.UsuarioReservaService
{
    public class UsuarioReservaServiceConsume : IUsuarioReservaServiceConsume
    {
        private readonly AppSetting _appSetting;
        public UsuarioReservaServiceConsume(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }

        public async Task<List<HotelView>> GetHotelList()
        {
            var HList = new List<HotelView>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/api/UsuarioReserva/GetHotelList");

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    HList = JsonConvert.DeserializeObject<List<HotelView>>(readTask);
                    return HList;
                }
            }
            return HList;
        }


        public async Task<List<UsuarioReservaView>> GetUsuarioReservaList(DateTime FechaEntrada, DateTime FechaSalida)
        {

            var FechaEntradaF = FechaEntrada.ToString("yyyy-MM-dd HH:mm:ss");
            var FechaSalidaF = FechaSalida.ToString("yyyy-MM-dd HH:mm:ss");

            var UserList = new List<UsuarioReservaView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/api/UsuarioReserva/" + FechaEntradaF + "/" + FechaSalidaF);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    UserList = JsonConvert.DeserializeObject<List<UsuarioReservaView>>(readTask);
                    return UserList;
                }
            }
            return UserList;
        }

        public async Task<bool> SaveUsuarioReserva(UsuarioReservaView model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/UsuarioReserva/AddUsuarioReserva", content);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(readTask);

                    return result;
                }
            }
            return false;
        }

        public async Task<bool> UpdateUsuarioReserva(UpdateReservaHotelView model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PutAsync("/api/UsuarioReserva/UpdateUsuarioReserva", content);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(readTask);

                    return result;
                }
            }
            return false;
        }
    }
}
