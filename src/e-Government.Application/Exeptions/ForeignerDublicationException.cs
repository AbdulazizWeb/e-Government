namespace e_Government.Application.Exeptions
{
    public class ForeignerDublicationException : Exception
    {
        private const string alreadyExists = "Foreigner already exists";

        public ForeignerDublicationException()
            : base(alreadyExists) { }

        public ForeignerDublicationException(Exception innerException)
            : base(alreadyExists, innerException) { }
    }
}