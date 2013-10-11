using System;

public class ErrorResultsException : Exception
{
    public ErrorResultsException()
    {
    }

    public ErrorResultsException(string message)
        : base(message)
    {
    }

    public ErrorResultsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}