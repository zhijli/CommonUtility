namespace ZhijieLi.CommonUtility.Logger
{
    using System.IO;
    using System.Runtime.Serialization.Formatters;
    using Newtonsoft.Json;

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
                _serializer.TypeNameHandling = TypeNameHandling.None;
            }
            using (var sw = new StringWriter())
            using (var writer = new JsonTextWriter(sw))
            {
                _serializer.Serialize(writer, obj);
                return sw.ToString();
            }
        }

        public static string DebugInfoTest<T>(this T obj, bool detail)
        {
            if (!detail)
            {
                _serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                _serializer.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;
                _serializer.TypeNameHandling = TypeNameHandling.None;
            }
            using (var sw = new StringWriter())
            using (var writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("CPU");
                writer.WriteValue("Intel");
                writer.WritePropertyName("PSU");
                writer.WriteValue("500W");
                writer.WritePropertyName("Drives");
                writer.WriteStartArray();
                writer.WriteValue("DVD read/writer");
                writer.WriteComment("(broken)");
                writer.WriteValue("500 gigabyte hard drive");
                writer.WriteValue("200 gigabype hard drive");
                writer.WriteEnd();
                writer.WriteEndObject();

                return sw.ToString();
            }
        }
    }
}
