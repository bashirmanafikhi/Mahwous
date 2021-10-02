using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mahwous.Application.Extensions
{
    public static class IFormFileExtensions
    {
        public static MemoryStream ToMemoryStream(this IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms;
            }
        }

        public static byte[] ToByteArray(this IFormFile file)
        {
            return ToMemoryStream(file).ToArray();
        }
    }
}
