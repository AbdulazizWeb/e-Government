using e_Government.Domain.Exceptions;

namespace e_Government.Application.Exeptions
{
    public class CertificateNotFoundException : EntityNotFoundException
    {
        private const string notFound = "Certificate not found";
        public CertificateNotFoundException()
            : base(notFound) { }
    }
}
