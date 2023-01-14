namespace Infrastructure.Exceptions
{
    public class InvalidInputValueException : Exception
    {
        public InvalidInputValueException() : base() { }
        public InvalidInputValueException(string message) : base(message) { }
    }
}
