namespace e_Government.Application.Exeptions
{
    public class PopulationDublicationException : Exception
    {
        private const string alreadyExists = "LegalEntity already exists";

        public PopulationDublicationException()
            : base(alreadyExists) { }

        public PopulationDublicationException(Exception innerException)
            : base(alreadyExists, innerException) { }
    }
}