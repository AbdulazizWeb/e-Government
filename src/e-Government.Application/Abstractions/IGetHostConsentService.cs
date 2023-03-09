using e_Government.Application.DIOs;

namespace e_Government.Application.Abstractions
{
    public interface IGetHostConsentService
    {
        bool GetHostConsent(RequestGetHostConsentModel requestGetHostConsent);
    }
}
