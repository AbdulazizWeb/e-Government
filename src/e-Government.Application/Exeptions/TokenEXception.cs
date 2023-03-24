using e_Government.Domain.Exceptions;

namespace e_Government.Application.Exeptions
{
    public class TokenException : Exception
    {
        private const string alreadyExists = "Sorry, You are not eligible for tokens!!!";
        public TokenException() : base(alreadyExists) { }
    }
}

