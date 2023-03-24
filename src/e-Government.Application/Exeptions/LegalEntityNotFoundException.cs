using e_Government.Domain.Exceptions;

namespace e_Government.Application.Exeptions
{
    public class LegalEntityNotFoundException : EntityNotFoundException
    {
        private const string notFound = "Legal entity";
        public LegalEntityNotFoundException() : base(notFound) { }
    }
}

