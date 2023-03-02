﻿using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class RequiredCertaintyTests
    {
        [Fact]
        public void ValidRequiredCertainty()
        {
            var info = InfoCreator.CreateValidInfo();
            var certaintyValidator = new CertaintyRequiredValidator(info);
            Assert.True(certaintyValidator.IsValid);
            Assert.Empty(certaintyValidator.Errors);
        }

        [Fact]
        public void InvalidRequiredCertainty()
        {
            var certaintyValidator = new CertaintyRequiredValidator(new Info());
            Assert.False(certaintyValidator.IsValid);
            Assert.Single(certaintyValidator.Errors);
        }
    }
}
