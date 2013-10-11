using System;

public class NoResultsException : Exception
{
    public NoResultsException()
    {
    }

    public NoResultsException(string message)
        : base(message)
    {
    }

    public NoResultsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}