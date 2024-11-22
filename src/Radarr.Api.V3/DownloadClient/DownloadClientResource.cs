using NzbDrone.Core.Download;
using NzbDrone.Core.Indexers;

namespace Radarr.Api.V3.DownloadClient
{
    public class DownloadClientResource : ProviderResource<DownloadClientResource>
    {
        public bool Enable { get; set; }
        public DownloadProtocol Protocol { get; set; }
        public int Priority { get; set; }
        public bool RemoveCompletedDownloads { get; set; }
        public bool RemoveFailedDownloads { get; set; }
        public bool SeedboxEnabled { get; set; }
        public string SeedboxFTPHost { get; set; }
        public string SeedboxFTPUser { get; set; }
        public string SeedboxFTPPassword { get; set; }
    }

    public class DownloadClientResourceMapper : ProviderResourceMapper<DownloadClientResource, DownloadClientDefinition>
    {
        public override DownloadClientResource ToResource(DownloadClientDefinition definition)
        {
            if (definition == null)
            {
                return null;
            }

            var resource = base.ToResource(definition);

            resource.Enable = definition.Enable;
            resource.Protocol = definition.Protocol;
            resource.Priority = definition.Priority;
            resource.RemoveCompletedDownloads = definition.RemoveCompletedDownloads;
            resource.RemoveFailedDownloads = definition.RemoveFailedDownloads;
            resource.SeedboxEnabled = definition.SeedboxEnabled;
            resource.SeedboxFTPHost = definition.SeedboxFTPHost;
            resource.SeedboxFTPUser = definition.SeedboxFTPUser;
            resource.SeedboxFTPPassword = definition.SeedboxFTPPassword;

            return resource;
        }

        public override DownloadClientDefinition ToModel(DownloadClientResource resource, DownloadClientDefinition existingDefinition)
        {
            if (resource == null)
            {
                return null;
            }

            var definition = base.ToModel(resource, existingDefinition);

            definition.Enable = resource.Enable;
            definition.Protocol = resource.Protocol;
            definition.Priority = resource.Priority;
            definition.RemoveCompletedDownloads = resource.RemoveCompletedDownloads;
            definition.RemoveFailedDownloads = resource.RemoveFailedDownloads;
            definition.SeedboxEnabled = resource.SeedboxEnabled;
            definition.SeedboxFTPHost =  resource.SeedboxFTPHost;
            definition.SeedboxFTPUser = resource.SeedboxFTPUser;
            definition.SeedboxFTPPassword = resource.SeedboxFTPPassword;

            return definition;
        }
    }
}
