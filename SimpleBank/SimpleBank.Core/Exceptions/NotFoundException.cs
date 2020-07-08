namespace SimpleBank.Core.Exceptions
{
    public class NotFoundException<T> : DomainException
    {
        public NotFoundException(in long id) : base($"{typeof(T).Name} with id: {id} not found")
        {
        }

        public NotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}