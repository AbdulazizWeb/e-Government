using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using Newtonsoft.Json;
using System.IO;

namespace e_Government.Infrastructure.Services
{
    public class BringAddressServise : IBringAddressService
    {
        public ResponseAddressModel BringAddressId(RequestAddressModel searchAddressModel)
        {

            //Bu yerda Client yozilishi kerak!!!
            /* using HttpClient client = new HttpClient();
             //HttpContent

             var responce = await client.GetAsync($"https://datausa.io/api/data?drilldowns={searchAddressModel.}&searchAddressModel");

             var result = await responce.Content.ReadAsStringAsync();

             var responseAddressModel = JsonConvert.DeserializeObject<ResponseAddressModel>(result);           

             return responseAddressModel;*/

            var response = new ResponseAddressModel
            {
                Id = 12,
                HostId = 3
            };

            return response;
        }

        public RequestAddressModel BringFullAddress(int id)
        {
            //Bu yerda Client yozilishi kerak!!!
            /*var client = new HttpClient();

            var responce = await client.GetAsync("https://datausa.io/api/data?drilldowns=Nation&measures=id");

            var result = await responce.Content.ReadAsStringAsync();

            var requestAddressModel = JsonConvert.DeserializeObject<RequestAddressModel>(result);

            return requestAddressModel;*/

            var response = new RequestAddressModel
            {
                BuildingNumber = "A1",
                StreetName = "Wall street",
                CityName = "Brooklyn"
            };

            return response;
        }       
    }
}

