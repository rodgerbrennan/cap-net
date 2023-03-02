﻿using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class MimeTypeRequiredValidatorTests
    {
        [Fact]
        public void ResourceWithEmptyMimeTypeIsInvalid()
        {
            var resource = new Resource();
            resource.MimeType = "";
            var mimeTypeValidator = new MimeTypeRequiredValidator(resource);
            Assert.False(mimeTypeValidator.IsValid);
            Assert.Single(mimeTypeValidator.Errors);
        }

        [Fact]
        public void ResourceWithMimeTypeIsValid()
        {
            var resource = new Resource();
            resource.MimeType = "image/jpeg";
            var mimeTypeValidator = new MimeTypeRequiredValidator(resource);
            Assert.True(mimeTypeValidator.IsValid);
        }
    }
}
