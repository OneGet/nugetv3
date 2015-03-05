using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OneGet.NuGetProviderV3;
using OneGet.Sdk;

namespace NuGetProviderV3Tests
{
    internal class MockRequest : Request
    {
        List<PackageSource> _packageSources = new List<PackageSource>();
        MockProviderServices _providerServices = new MockProviderServices();

        public override dynamic PackageManagementService
        {
            get { throw new NotImplementedException(); }
        }

        public override IProviderServices ProviderServices => _providerServices;

        public override bool IsCanceled
        {
            get { throw new NotImplementedException(); }
        }

        public override string GetMessageString(string messageText, string defaultText)
        {
            throw new NotImplementedException();
        }

        public override bool Warning(string messageText)
        {
            Console.WriteLine("WARNING: {0}", messageText);
            return true;
        }

        public override bool Error(string id, string category, string targetObjectValue, string messageText)
        {
            Console.WriteLine("ERROR. Id='{0}', Category='{1}', TargetObjectValue='{2}', Message='{3}'", id, category, targetObjectValue, messageText);
            return true;
        }

        public override bool Message(string messageText)
        {
            Console.WriteLine("MESSAGE: {0}", messageText);
            return true;
        }

        public override bool Verbose(string messageText)
        {
            Console.WriteLine("VERBOSE: {0}", messageText);
            return true;
        }

        public override bool Debug(string messageText)
        {
            Console.WriteLine("DEBUG: {0}", messageText);
            return true;
        }

        public override int StartProgress(int parentActivityId, string messageText)
        {
            throw new NotImplementedException();
        }

        public override bool Progress(int activityId, int progressPercentage, string messageText)
        {
            throw new NotImplementedException();
        }

        public override bool CompleteProgress(int activityId, bool isSuccessful)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> OptionKeys
        {
            get { throw new NotImplementedException(); }
        }

        public override IEnumerable<string> GetOptionValues(string key)
        {
            return null;
        }

        public override IEnumerable<string> Sources { get; } = new List<string>();

        public override string CredentialUsername
        {
            get { throw new NotImplementedException(); }
        }

        public override SecureString CredentialPassword
        {
            get { throw new NotImplementedException(); }
        }

        public override bool ShouldBootstrapProvider(string requestor, string providerName, string providerVersion, string providerType,
            string location, string destination)
        {
            throw new NotImplementedException();
        }

        public override bool ShouldContinueWithUntrustedPackageSource(string package, string packageSource)
        {
            throw new NotImplementedException();
        }

        public override bool AskPermission(string permission)
        {
            throw new NotImplementedException();
        }

        public override bool IsInteractive
        {
            get { throw new NotImplementedException(); }
        }

        public override int CallCount
        {
            get { throw new NotImplementedException(); }
        }

        public override bool YieldSoftwareIdentity(string fastPath, string name, string version, string versionScheme, string summary,
            string source, string searchKey, string fullPath, string packageFileName)
        {
            throw new NotImplementedException();
        }

        public override bool YieldSoftwareMetadata(string parentFastPath, string name, string value)
        {
            throw new NotImplementedException();
        }

        public override bool YieldEntity(string parentFastPath, string name, string regid, string role, string thumbprint)
        {
            throw new NotImplementedException();
        }

        public override bool YieldLink(string parentFastPath, string referenceUri, string relationship, string mediaType, string ownership,
            string use, string appliesToMedia, string artifact)
        {
            throw new NotImplementedException();
        }

        public override bool YieldPackageSource(string name, string location, bool isTrusted, bool isRegistered, bool isValidated)
        {
            _packageSources.Add(new PackageSource() { Name = name, Location = location, Trusted = isTrusted, IsRegistered = isRegistered, IsValidated = isValidated });
            ((List<string>)Sources).Add(name);
            return true;
        }

        public override bool YieldDynamicOption(string name, string expectedType, bool isRequired)
        {
            throw new NotImplementedException();
        }

        public override bool YieldKeyValuePair(string key, string value)
        {
            throw new NotImplementedException();
        }

        public override bool YieldValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}
