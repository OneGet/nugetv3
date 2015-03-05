using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneGet.Sdk;

namespace NuGetProviderV3Tests
{
    class MockProviderServices : Request.IProviderServices
    {
        public bool IsElevated
        {
            get { throw new NotImplementedException(); }
        }

        public string GetCanonicalPackageId(string providerName, string packageName, string version)
        {
            throw new NotImplementedException();
        }

        public string ParseProviderName(string canonicalPackageId)
        {
            throw new NotImplementedException();
        }

        public string ParsePackageName(string canonicalPackageId)
        {
            throw new NotImplementedException();
        }

        public string ParsePackageVersion(string canonicalPackageId)
        {
            throw new NotImplementedException();
        }

        public void DownloadFile(Uri remoteLocation, string localFilename, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public bool IsSupportedArchive(string localFilename, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> UnpackArchive(string localFilename, string destinationFolder, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void AddPinnedItemToTaskbar(string item, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void RemovePinnedItemFromTaskbar(string item, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void CreateShortcutLink(string linkPath, string targetPath, string description, string workingDirectory,
            string arguments, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void SetEnvironmentVariable(string variable, string value, string context, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void RemoveEnvironmentVariable(string variable, string context, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void CopyFile(string sourcePath, string destinationPath, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(string path, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void DeleteFolder(string folder, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void CreateFolder(string folder, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public void DeleteFile(string filename, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public string GetKnownFolder(string knownFolder, Request requestObject)
        {
            if (String.Equals(knownFolder,"ApplicationData"))
            {
                // for tests, use a relative path
                return "";
            }
            throw new NotImplementedException();
        }

        public string CanonicalizePath(string text, string currentDirectory)
        {
            throw new NotImplementedException();
        }

        public bool FileExists(string path)
        {
            throw new NotImplementedException();
        }

        public bool DirectoryExists(string path)
        {
            throw new NotImplementedException();
        }

        public bool Install(string fileName, string additionalArgs, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public bool IsSignedAndTrusted(string filename, Request requestObject)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteElevatedAction(string provider, string payload, Request requestObject)
        {
            throw new NotImplementedException();
        }
    }
}
