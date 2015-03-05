using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OneGet.Sdk;

namespace Microsoft.OneGet.NuGetProviderV3
{
    internal static class ExtensionMethods
    {
        internal static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        internal static IEnumerable<T> AsEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}
