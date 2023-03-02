using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class RequiredUrgencyTests
    {
        [Fact]
        public void ValidRequiredUrgency()
        {
            var info = InfoCreator.CreateValidInfo();
            var urgencyValidator = new UrgencyRequiredValidator(info);
            Assert.True(urgencyValidator.IsValid);
            Assert.Empty(urgencyValidator.Errors);
        }

        [Fact]
        public void InvalidRequiredUrgency()
        {
            var urgencyValidator = new UrgencyRequiredValidator(new Info());
            Assert.False(urgencyValidator.IsValid);
            Assert.Single(urgencyValidator.Errors);
        }
    }
}
