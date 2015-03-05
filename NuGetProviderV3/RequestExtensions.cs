using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OneGet.NuGetProviderV3;
using OneGet.Sdk;

namespace Microsoft.OneGet.NuGetProviderV3
{
    internal static class RequestExtensions
    {
        internal static bool YieldPackage(this Request request, PackageItem pkg, string searchKey)
        {
            try
            {
                if (request.YieldSoftwareIdentity(pkg.FastPath, pkg.Package.Id, pkg.Package.Version.ToString(), "semver", pkg.Package.Summary, pkg.PackageSource.Name, searchKey, pkg.FullPath, pkg.PackageFilename))
                {
                    /*if (!request.YieldSoftwareMetadata(pkg.FastPath, "copyright", pkg.Package.Copyright))
                    {
                        return false;
                    }*/
                    if (!request.YieldSoftwareMetadata(pkg.FastPath, "description", pkg.Package.Description))
                    {
                        return false;
                    }/*
                    if (!request.YieldSoftwareMetadata(pkg.FastPath, "language", pkg.Package.Language))
                    {
                        return false;
                    }
                    if (!request.YieldSoftwareMetadata(pkg.FastPath, "releaseNotes", pkg.Package.ReleaseNotes))
                    {
                        return false;
                    }*/
                    if (pkg.Package.Published != null)
                    {
                        // published time.
                        if (!request.YieldSoftwareMetadata(pkg.FastPath, "published", pkg.Package.Published.ToString()))
                        {
                            return false;
                        }
                    }
                    if (!request.YieldSoftwareMetadata(pkg.FastPath, "tags", pkg.Package.Tags))
                    {
                        return false;
                    }
                    if (!request.YieldSoftwareMetadata(pkg.FastPath, "title", pkg.Package.Title))
                    {
                        return false;
                    }
                    if (
                        !request.YieldSoftwareMetadata(pkg.FastPath, "FromTrustedSource", pkg.PackageSource.Trusted.ToString()))
                    {
                        return false;
                    }
                    if (pkg.Package.LicenseUrl != null && !String.IsNullOrEmpty(pkg.Package.LicenseUrl.ToString()))
                    {
                        if (
                            !request.YieldLink(pkg.FastPath, pkg.Package.LicenseUrl.ToString(), "license", null, null,
                                null, null, null))
                        {
                            return false;
                        }
                    }
                    if (pkg.Package.ProjectUrl != null && !String.IsNullOrEmpty(pkg.Package.ProjectUrl.ToString()))
                    {
                        if (
                            !request.YieldLink(pkg.FastPath, pkg.Package.ProjectUrl.ToString(), "project", null, null,
                                null, null, null))
                        {
                            return false;
                        }
                    }
                    if (pkg.Package.ReportAbuseUrl != null &&
                        !String.IsNullOrEmpty(pkg.Package.ReportAbuseUrl.ToString()))
                    {
                        if (
                            !request.YieldLink(pkg.FastPath, pkg.Package.ReportAbuseUrl.ToString(), "abuse", null, null,
                                null, null, null))
                        {
                            return false;
                        }
                    }
                    if (pkg.Package.IconUrl != null && !String.IsNullOrEmpty(pkg.Package.IconUrl.ToString()))
                    {
                        if (
                            !request.YieldLink(pkg.FastPath, pkg.Package.IconUrl.ToString(), "icon", null, null, null,
                                null, null))
                        {
                            return false;
                        }
                    }
                    if (
                        pkg.Package.Authors.Any(
                            author => !request.YieldEntity(pkg.FastPath, author.Trim(), author.Trim(), "author", null)))
                    {
                        return false;
                    }

                    if (
                        pkg.Package.Owners.Any(
                            owner => !request.YieldEntity(pkg.FastPath, owner.Trim(), owner.Trim(), "owner", null)))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                request.Error(ErrorCategory.InvalidData, pkg.Id, Strings.PackageMissingProperty, pkg.Id);
            }

            return true;
        }
    }
}
