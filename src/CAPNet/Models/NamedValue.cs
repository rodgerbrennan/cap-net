using System.Xml.Serialization;
namespace CAPNet.Models
{
    /// <summary>
    /// Base class for values with names (e.g. EventCode, GeoCode)
    /// </summary>
    [XmlRoot("namedValue")]
    public class NamedValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        protected NamedValue(string valueName, string value)
        {
            ValueName = valueName;
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("value")]
        public string Value { get; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("valueName")]
        public string ValueName { get; }
    }
}