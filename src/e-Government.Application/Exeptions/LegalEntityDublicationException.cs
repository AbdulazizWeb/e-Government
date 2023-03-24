namespace e_Government.Application.Exeptions
{
    public class LegalEntityDublicationException : Exception
    {
        private const string alreadyExists = "LegalEntity already exists";

        public LegalEntityDublicationException()
            : base(alreadyExists) { }

        public LegalEntityDublicationException(Exception innerException)
            : base(alreadyExists, innerException) { }
    }
}