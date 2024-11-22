using System;
using Equ;
using NzbDrone.Core.Indexers;
using NzbDrone.Core.ThingiProvider;

namespace NzbDrone.Core.Download
{
    public class DownloadClientDefinition : ProviderDefinition, IEquatable<DownloadClientDefinition>
    {
        private static readonly MemberwiseEqualityComparer<DownloadClientDefinition> Comparer = MemberwiseEqualityComparer<DownloadClientDefinition>.ByProperties;

        [MemberwiseEqualityIgnore]
        public DownloadProtocol Protocol { get; set; }

        public int Priority { get; set; } = 1;
        public bool RemoveCompletedDownloads { get; set; } = true;
        public bool RemoveFailedDownloads { get; set; } = true;
        public bool SeedboxEnabled { get; set; }
        public string SeedboxFTPHost { get; set; }
        public string SeedboxFTPUser { get; set; }
        public string SeedboxFTPPassword { get; set; }

        public bool Equals(DownloadClientDefinition other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DownloadClientDefinition);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }
    }
}
