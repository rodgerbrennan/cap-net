using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// Validator of the multiple instances that MAY occur within an area block.
    /// </summary>
    public class GeoCodesValidator : Validator<Area>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        public GeoCodesValidator(Area area) : base(area) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from geocode in Entity.GeoCodes
                       from error in GetErrors(geocode)
                       select error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geocode"></param>
        /// <returns></returns>
        private static IEnumerable<Error> GetErrors(GeoCode geocode)
        {
            return geocode.GetErrorsFromAllEntityValidators();
        }
    }
}
