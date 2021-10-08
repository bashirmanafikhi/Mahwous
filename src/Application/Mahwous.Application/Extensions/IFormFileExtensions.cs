using Microsoft.AspNetCore.Http;
using System.IO;

namespace Mahwous.Application.Extensions
{
    public static class IFormFileExtensions
    {
        public static MemoryStream ToMemoryStream(this IFormFile file)
        {
            if (file == null) return null;

            var ms = new MemoryStream();
            file.CopyTo(ms);
            return ms;
        }

        public static byte[] ToByteArray(this IFormFile file)
        {
            return ToMemoryStream(file)?.ToArray();
        }
    }
}
