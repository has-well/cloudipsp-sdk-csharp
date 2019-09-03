using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace CloudIpspSDK.Utils
{
    public abstract class XmlFormatter
    {
        // override StringWriter
        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }

        /// <summary>
        /// Return xml response as dict
        /// </summary>
        /// <param name="xmlResponse"></param>
        /// <returns></returns>
        public static T ConvertFromXml<T>(string xmlResponse)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(RemoveInvalidXmlChars(xmlResponse)))
            {
                var xml = (T) serializer.Deserialize(sr);
                return xml;
            }
        }

        static string RemoveInvalidXmlChars(string text)
        {
            var validXmlChars = text.Where(XmlConvert.IsXmlChar).ToArray();
            return new string(validXmlChars).Replace("\\n", "");
        }

        /// <summary>
        /// Convert to XMl
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ConvertToXml<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (var sr = new Utf8StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sr))
                {
                    serializer.Serialize(writer, obj);
                    return sr.ToString();
                }
            }
        }

        public static string ConvertToXmlSimple(object obj)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});
            var serializer = new XmlSerializer(obj.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, obj, emptyNamespaces);
                return stream.ToString();
            }
        }
    }
}