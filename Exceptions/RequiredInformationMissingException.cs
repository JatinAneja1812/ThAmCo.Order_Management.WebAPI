namespace Exceptions
{
    public class RequiredInformationMissingException : Exception
    {
        public RequiredInformationMissingException()
        {
        }

        public RequiredInformationMissingException(string message)
            : base(message)
        {
        }

        public RequiredInformationMissingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
