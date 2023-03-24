using e_Government.Application.DIOs;

namespace e_Government.Application.Abstractions
{
    public interface IBringAddressService
    {
        ResponseAddressModel BringAddressId(RequestAddressModel searchAddressModel);
        RequestAddressModel BringFullAddress(int id);
    }
}
