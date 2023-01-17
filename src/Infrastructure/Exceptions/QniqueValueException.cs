namespace Infrastructure.Exceptions
{
    public class QniqueValueException : Exception
    {
        public QniqueValueException() : base() { }
        public QniqueValueException(string message) : base(message) { }
    }
}
