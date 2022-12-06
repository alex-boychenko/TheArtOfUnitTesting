namespace TheArtOfUnitTesting;

internal class Precondition
{
    internal static void Requires(bool condition)
    {
        if (!condition) throw new PreconditionException();
    }
}

internal class PreconditionException : Exception { }
