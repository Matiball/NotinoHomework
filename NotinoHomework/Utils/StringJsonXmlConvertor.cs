using Newtonsoft.Json;
using NotinoHomework.Models;
using System.Xml;
using System.Xml.Linq;

namespace NotinoHomework.Utils
{
    public class StringJsonXmlConvertor
    {
        private static readonly XDeclaration _defaultDeclaration = new("1.0", null, null);

        public static string ConvertXMLtoJSON(string xmlInput)
        {
            //load xml
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlInput);

            var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
            return json;

            //Document document = JsonConvert.DeserializeObject<Document>(json);
            //return document;
        }

        public static string ConvertJSONtoXML(string jsonInput)
        {
            var doc = JsonConvert.DeserializeXNode(jsonInput, "root")!;

            // if left side not null, dont evaluate right side just return left
            // if left side null, then return rigth
            var declaration = doc.Declaration ?? _defaultDeclaration;

            return $"{declaration}{Environment.NewLine}{doc}";
        }
    }
}
