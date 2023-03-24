using e_Government.Domain.Exceptions;

namespace e_Government.Application.Exeptions
{
    public class UsingMinistryNameException : Exception
    {
        private const string notFound = "It is forbidden to use the name of the Ministry";
        public UsingMinistryNameException() : base(notFound) { }
    }
}

