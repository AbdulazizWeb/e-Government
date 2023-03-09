using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;

namespace e_Government.Infrastructure.Services
{
    public class BringAddressServise : IBringAddressService
    {
        public ResponseAddressModel BringAddressId(RequestAddressModel searchAddressModel)
        {

            //Bu yerda Client yozilishi kerak!!!

            var response = new ResponseAddressModel
            {
                Id = 12,
                HostId = 1
            };

            return response;
        }

        public RequestAddressModel BringFullAddress(int id)
        {
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

