using NzbDrone.Core.Download.TrackedDownloads;

namespace NzbDrone.Core.Download
{
    public interface ISeedboxFTPService
    {
        void Check(TrackedDownload trackedDownload);
    }

    public class SeedboxFTPService : ISeedboxFTPService
    {
        private readonly IProvideDownloadClient _downloadClientProvider;

        public SeedboxFTPService(
            IProvideDownloadClient downloadClientProvider)
        {
            _downloadClientProvider = downloadClientProvider;
        }

        public void Check(TrackedDownload trackedDownload)
        {
            var downloadClient = _downloadClientProvider.Get(trackedDownload.DownloadClient);
            var definition = (DownloadClientDefinition)downloadClient.Definition;
        }
    }
}
