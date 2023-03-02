using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class RequiredCategoriesTests
    {
        [Fact]
        public void ValidRequiredCategories()
        {
            var info = InfoCreator.CreateValidInfo();
            var categoriesValidator = new CategoryRequiredValidator(info);
            Assert.True(categoriesValidator.IsValid);
            Assert.Empty(categoriesValidator.Errors);
        }

        [Fact]
        public void InvalidRequiredCategories()
        {
            var categoryValidator = new CategoryRequiredValidator(new Info());
            Assert.False(categoryValidator.IsValid);
            Assert.Single(categoryValidator.Errors);
        }
    }
}
