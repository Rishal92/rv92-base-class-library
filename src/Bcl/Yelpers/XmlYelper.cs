using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Bcl.Yelpers
{
    public static class XmlYelper
    {
        public static string SerializeObjectToXml<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            var xmlSettings = new XmlWriterSettings { CheckCharacters = true };
            using var sww = new StringWriter();
            var writer = XmlWriter.Create(sww, xmlSettings);

            serializer.Serialize(writer, obj);
            var result = sww.ToString();

            return result;
        }
    }
}