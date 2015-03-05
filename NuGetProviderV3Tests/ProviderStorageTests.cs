using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft.OneGet.NuGetProviderV3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneGet.Sdk;
using System.Linq;

namespace NuGetProviderV3Tests
{
    [TestClass]
    public class ProviderStorageTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var configFilePath = Path.Combine("NuGet", "NuGet.config");
            File.Delete(configFilePath);
        }

        [TestMethod]
        public void ResolvePackageSourcesEmptyTest()
        {
            var provider = new NuGetV3PackageProvider();
            var request = new MockRequest();

            provider.ResolvePackageSources(request);
            Assert.AreEqual(0, request.PackageSources.Count());
        }

        [TestMethod]
        public void AddPackageSourcesTest()
        {
            var provider = new NuGetV3PackageProvider();
            var request = new MockRequest();

            provider.AddPackageSource("TestSource", "http://testlocation", true, request);
            provider.ResolvePackageSources(request);
            Assert.AreEqual(1, request.PackageSources.Count());
            Assert.AreEqual("TestSource", request.PackageSources.First());
        }

        [TestMethod]
        public void RemovePackageSourcesTest()
        {
            var provider = new NuGetV3PackageProvider();
            var request = new MockRequest();

            provider.AddPackageSource("TestSource", "http://testlocation", true, request);
            provider.ResolvePackageSources(request);
            Assert.AreEqual(1, request.PackageSources.Count());

            provider.RemovePackageSource("TestSource", request);

            var newRequest = new MockRequest();
            provider.ResolvePackageSources(newRequest);
            Assert.AreEqual(0, newRequest.PackageSources.Count());
        }
    }
}
