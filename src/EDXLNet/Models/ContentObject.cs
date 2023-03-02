using System.Xml.Serialization;

namespace EDXLNet.Models
{
    [XmlRoot("contentObject")]
    public class ContentObject
    {
        [XmlAttribute("contentXML")]
        public ContentXml ContentXml { get; set; }
    }
}