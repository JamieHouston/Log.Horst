using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogs.Utils
{
    //http://stackoverflow.com/questions/9543715/generating-human-readable-usable-short-but-unique-ids
    public static class ShortUidGenerator
    {
        private static readonly char[] Chars =
            "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
            .ToCharArray();

        private static readonly Random Random = new Random();

        public static string GenerateUid(int length = 5)
        {
            var sb = new StringBuilder(length);

            for (var i = 0; i < length; i++)
                sb.Append(Chars[Random.Next(62)]);

            return sb.ToString();
        }
    }
}
