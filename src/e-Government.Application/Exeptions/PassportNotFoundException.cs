using e_Government.Domain.Exceptions;

namespace e_Government.Application.Exeptions
{
    public class PassportNotFoundException : EntityNotFoundException
    {
        private const string notFound = "Passport not found";
        public PassportNotFoundException() : base(notFound) { }
    }
}

