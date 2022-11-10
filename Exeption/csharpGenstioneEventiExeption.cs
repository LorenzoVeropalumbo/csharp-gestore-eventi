using System.Runtime.Serialization;

[Serializable]
internal class csharpGenstioneEventiExeption : Exception
{
    public csharpGenstioneEventiExeption()
    {
    }

    public csharpGenstioneEventiExeption(string? message) : base(message)
    {
    }

    public csharpGenstioneEventiExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected csharpGenstioneEventiExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}