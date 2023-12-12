namespace Exceptions
{
    public class OrderExistsException : Exception
    {
        public OrderExistsException()
        {
        }

        public OrderExistsException(string message)
            : base(message)
        {
        }

        public OrderExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}