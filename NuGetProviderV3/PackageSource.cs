﻿// 
//  Copyright (c) Microsoft Corporation. All rights reserved. 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  

using System.Text;
using Newtonsoft.Json;

namespace Microsoft.OneGet.NuGetProviderV3
{
    using System;
    using System.IO;
    using NuGet;

    internal class PackageSource
    {
        private IPackageRepository _repository;

        [JsonProperty]
        internal string Name { get; set; }

        [JsonProperty]
        internal string Location { get; set; }

        [JsonProperty]
        internal bool Trusted { get; set; }

        [JsonProperty]
        internal bool IsRegistered { get; set; }

        [JsonProperty]
        internal bool IsValidated { get; set; }

        internal IPackageRepository Repository
        {
            get
            {
                if (!IsSourceAFile)
                {
                    return _repository ?? (_repository = PackageRepositoryFactory.Default.CreateRepository(Location));
                }
                return null;
            }
        }

        internal bool IsSourceAFile
        {
            get
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(Location) && ((!Uri.IsWellFormedUriString(Location, UriKind.Absolute) || new Uri(Location).IsFile) && File.Exists(Location)))
                    {
                        return true;
                    }
                }
                catch
                {
                    // no worries.
                }
                return false;
            }
        }

        internal bool IsSourceADirectory
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(Location) && Directory.Exists(Location))
                    {
                        return true;
                    }
                }
                catch
                {
                    // no worries.
                }
                return false;
            }
        }

        internal string Serialized
        {
            get { return Location.ToBase64(); }
        }
    }
}