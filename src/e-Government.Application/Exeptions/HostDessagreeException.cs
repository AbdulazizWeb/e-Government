namespace e_Government.Application.Exeptions
{
    public class HostDessagreeException : Exception
    {
        private const string notFound = "The host disagrees!!!";
        public HostDessagreeException()
            : base(notFound) { }

        public HostDessagreeException(Exception innerException)
            : base(notFound, innerException) { }
    }
}
