using System.Collections.Generic;
using System.Xml.Serialization;

namespace EDXLNet.Models
{
    [XmlRoot("content")]
    public class Content
    {
        private readonly ICollection<ContentObject> contentObjects = new List<ContentObject>();

        [XmlElement("contentObjects")]
        public ICollection<ContentObject> ContentObjects
        {
            get { return contentObjects; }
        }
    }
}