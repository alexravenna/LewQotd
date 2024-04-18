using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;

namespace Qotd.Shared.Utilities;

public static class Util
{
    public static string LogAsJson<T>(this T obj, bool writeIndented = true) where T : class
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = writeIndented });
    }

    public static async Task<(byte[] fileContent, string fileContentType)> GetFile(IBrowserFile file)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(file));
        if (file.Size < 1) throw new ArgumentException("Dateilänge ist kleiner 1");

        var fileContentType = file.ContentType;
        var fileContent = await GetFileAsByteArrayAsync();

        async Task<byte[]> GetFileAsByteArrayAsync()
        {
            await using var stream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(stream);
            return stream.ToArray();
        }

        return (fileContent, fileContentType);
    }
}
