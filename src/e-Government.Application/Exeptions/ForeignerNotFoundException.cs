using e_Government.Domain.Exceptions;

namespace e_Government.Application.Exeptions
{
    public class ForeignerNotFoundException : EntityNotFoundException
    {
        private const string notFound = "Foreigner not found";
        public ForeignerNotFoundException() : base(notFound) { }
    }
}

