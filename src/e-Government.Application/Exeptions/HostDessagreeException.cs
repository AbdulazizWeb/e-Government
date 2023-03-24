namespace e_Government.Application.Exeptions
{
    public class HostDessagreeException : Exception
    {
        private const string deesagree = "The host disagrees!!!";
        public HostDessagreeException()
            : base(deesagree) { }

        public HostDessagreeException(Exception innerException)
            : base(deesagree, innerException) { }
    }
}
