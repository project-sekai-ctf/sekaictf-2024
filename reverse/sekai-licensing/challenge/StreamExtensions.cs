namespace license_server;

public static class StreamExtensions
{
    public static byte[] ReadAllBytes(this Stream inStream)
    {
        if (inStream is MemoryStream stream)
            return stream.ToArray();

        using var memoryStream = new MemoryStream();
        inStream.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
    
    public static async Task<byte[]> ReadAllBytesAsync(this Stream inStream)
    {
        if (inStream is MemoryStream stream)
            return stream.ToArray();

        using var memoryStream = new MemoryStream();
        await inStream.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
    
    public static async Task<byte[]> ReadAllBytesAsync(this Stream inStream, CancellationToken token)
    {
        if (inStream is MemoryStream stream)
            return stream.ToArray();

        using var memoryStream = new MemoryStream();
        await inStream.CopyToAsync(memoryStream, token);
        return memoryStream.ToArray();
    }
}