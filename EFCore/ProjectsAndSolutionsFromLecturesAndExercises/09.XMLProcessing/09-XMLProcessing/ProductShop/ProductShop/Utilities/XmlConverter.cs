using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Utilities
{
    public static class XmlConverter
    {
        static XmlSerializer xmlSerializer;

        static StringBuilder sb;

        static StringWriter writer;

        public static string Serialize<T>(T DTO, string xmlRootAttributeName)
        {
            xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            sb = new StringBuilder();

            writer = new StringWriter(sb);

            xmlSerializer.Serialize(writer, DTO, GetXmlNamespaces());

            return sb.ToString();
        }

        public static string Serialize<T>(T[] DTOs, string xmlRootAttributeName)
        {
            xmlSerializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));

            sb = new StringBuilder();

            writer = new StringWriter(sb);

            xmlSerializer.Serialize(writer, DTOs, GetXmlNamespaces());

            return sb.ToString();
        }

        public static T[] Deserialize<T>(string xmlObjects, string xmlRootAttributeName)
        {
            xmlSerializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));

            T[] DTOs = xmlSerializer.Deserialize(new StringReader(xmlObjects)) as T[];

            return DTOs;
        }

        public static T Deserialize<T>(string xmlObject, string xmlRootAttributeName, bool isOneObject)
            where T : class
        {
            xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            T DTO = xmlSerializer.Deserialize(new StringReader(xmlObject)) as T;

            return DTO;
        }

        private static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();

            xmlNamespaces.Add(string.Empty, string.Empty);

            return xmlNamespaces;
        }
    }
}
