using System.IO;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;

namespace Kid.CommonUtility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DebugHelper
    {
        private static JsonSerializer _serializer;

        static DebugHelper()
        {
            _serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Include,
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Full,
                TypeNameHandling = TypeNameHandling.All
            };

            _serializer.Error += (ser, err) => err.ErrorContext.Handled = true;
        }

        public static string DebugInfo<T>(this T obj)
        {
            using (var sw = new StringWriter())
            using (var writer = new JsonTextWriter(sw))
            {
                _serializer.Serialize(writer, obj);
                return sw.ToString();
            }
        }

        public static string DebugInfo<T>(this T obj, bool detail)
        {
            if (!detail)
            {
                _serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                _serializer.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;
                _serializer.TypeNameHandling     = TypeNameHandling.None;
            }
            using (var sw = new StringWriter())
            using (var writer = new JsonTextWriter(sw))
            {
                _serializer.Serialize(writer, obj);
                return sw.ToString();
            }
        }
    }
}
