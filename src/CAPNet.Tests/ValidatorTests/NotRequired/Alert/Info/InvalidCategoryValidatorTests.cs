using System.Linq;
using Xunit;

namespace CAPNet
{
    public class InvalidCategoryValidatorTests
    {
        [Fact]
        public void CategoryWithValidValueFromTheCategoryEnumIsValid()
        {
            var info = InfoCreator.CreateValidInfo();
            
            var categoryValidator = new InvalidCategoryValidator(info);
            Assert.True(categoryValidator.IsValid);
            Assert.Empty(categoryValidator.Errors);
        }

        [Fact]
        public void CategoryWithInvalidValueFromTheCategoryEnumIsInvalid()
        {
            var info = InfoCreator.CreateInvalidCategory();

            var categoryValidator = new InvalidCategoryValidator(info);
            Assert.False(categoryValidator.IsValid);
            Assert.Single(categoryValidator.Errors);
        }
    }
}
