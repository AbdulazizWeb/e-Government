using e_Government.Domain.Exceptions;

namespace e_Government.Application.Exeptions
{
    public class VisaNotFoundException : EntityNotFoundException
    {
        private const string notFound = "Visa not found";
        public VisaNotFoundException() : base(notFound) { }
    }
}

