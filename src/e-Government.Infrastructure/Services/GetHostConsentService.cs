using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;

namespace e_Government.Infrastructure.Services
{
    public class GetHostConsentService : IGetHostConsentService
    {
        public bool GetHostConsent(RequestGetHostConsentModel requestGetHostConsent)
        {
            Console.WriteLine(requestGetHostConsent.MessageForHost);
            Console.WriteLine("Agree or Dessagree");

            var answer = Console.ReadLine();

            Console.WriteLine($"Your answer was {answer}. Please enter your passport serial number for confirmation: ");
            var response = Console.ReadLine();

            if (response == requestGetHostConsent.HostDocumentSerialNumber && answer == "Agree")
            {
                return true;
            }

            return false;
        }
    }
}
