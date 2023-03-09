using e_Government.Domain.Exceptions;

namespace e_Government.Application.Exeptions
{
    public class PopulationNotFoundException : EntityNotFoundException
    {
        private const string notFound = "Population not found";
        public PopulationNotFoundException() : base(notFound) { }
    }
}

