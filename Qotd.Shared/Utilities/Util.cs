using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Qotd.Shared.Utilities;

public static class Util
{
    public static string LogAsJson<T>(this T obj, bool writeIntended = true) where T : class
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = writeIntended });
    }

    public static async Task<(byte[] fileContent, string fileContentType)> GetFile(IBrowserFile file)
    {
        ArgumentNullException.ThrowIfNull(nameof(file));
        if (file.Size < 1) throw new ArgumentException("Datei Länge ist kleiner 1");

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