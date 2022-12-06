namespace TheArtOfUnitTesting;

internal class Precondition
{
    internal static void Requires(bool condition)
    {
        if (!condition) throw new PreconditionException("smth went wrong");
    }
}

internal class PreconditionException : Exception
{
    public PreconditionException(string? message) : base(message)
    {
    }
}
