using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class RequiredSeverityTests
    {
        [Fact]
        public void ValidRequiredSeverity()
        {
            var info = InfoCreator.CreateValidInfo();
            var severityValidator = new SeverityRequiredValidator(info);
            Assert.True(severityValidator.IsValid);
            Assert.Empty(severityValidator.Errors);
        }

        [Fact]
        public void InvalidRequiredSeverity()
        {
            var severityValidator = new SeverityRequiredValidator(new Info());
            Assert.False(severityValidator.IsValid);
            Assert.Single(severityValidator.Errors);
        }
    }
}
