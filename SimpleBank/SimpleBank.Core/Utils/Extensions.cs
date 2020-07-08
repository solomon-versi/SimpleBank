using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SimpleBank.Core.Utils
{
    public static class Extensions
    {
        public static string ToJson<T>(this T self) => JsonSerializer.Serialize(self);

        public static string ToIndentedJson<T>(this T self) => JsonSerializer.Serialize(self, new JsonSerializerOptions { WriteIndented = true });

        public static T Deserialize<T>(this string json) => JsonSerializer.Deserialize<T>(json);
    }
}