using CAPNet.Models;
using CAPNet.Validator.Alert;

namespace CAPNet
{
    /// <summary>
    /// Any geographically-based code to describe a message must have value and valueName not null
    /// </summary>
    public class GeoCodeValidator : GeneralNamedValueValidator<GeoCode>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="geocode"></param>
        public GeoCodeValidator(GeoCode geocode) : base(geocode) { }
    }
}
