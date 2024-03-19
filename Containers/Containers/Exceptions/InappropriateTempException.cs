namespace Containers.Exceptions;

public class InappropriateTempException : Exception
{
    public InappropriateTempException()
    {
    }

    public InappropriateTempException(string message)
        : base(message)
    {
    }

    public InappropriateTempException(string message, Exception inner)
        : base(message, inner)
    {
    }
}