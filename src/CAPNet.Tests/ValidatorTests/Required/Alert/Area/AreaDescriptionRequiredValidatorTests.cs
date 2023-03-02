using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class AreaDescriptionRequiredValidatorTests
    {
        [Fact]
        public void AreaWithAreaDescriptionIsValid()
        {
            var area = new Area();
            area.Description = "U.S. nationwide and interests worldwide";

            var areaDescriptionRequiredValidator = new AreaDescriptionRequiredValidator(area);
            Assert.True(areaDescriptionRequiredValidator.IsValid);
            Assert.Empty(areaDescriptionRequiredValidator.Errors);
        }

        [Fact]
        public void AreaWithAreaDescriptionNullIsInvalid()
        {
            var area = new Area();
            area.Description = null;

            var areaDescriptionRequiredValidator = new AreaDescriptionRequiredValidator(area);
            Assert.False(areaDescriptionRequiredValidator.IsValid);
            Assert.Single(areaDescriptionRequiredValidator.Errors);
        }

        [Fact]
        public void AreaWithAreaDescriptionEmptyIsInvalid()
        {
            var area = new Area();
            area.Description = string.Empty;

            var areaDescriptionRequiredValidator = new AreaDescriptionRequiredValidator(area);
            Assert.False(areaDescriptionRequiredValidator.IsValid);
            Assert.Single(areaDescriptionRequiredValidator.Errors);
        }
    }
}
