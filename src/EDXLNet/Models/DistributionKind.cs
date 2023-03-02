using System.Xml.Serialization;

namespace EDXLNet.Models
{
    [XmlRoot("distributionKind")]
    public class DistributionKind
    {

        public DistributionKindDefault DistributionKindDefault { get; set; }
    }
}