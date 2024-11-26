using System.Collections.Concurrent;
using System.Threading.Tasks;

// using FluentFTP;
using NzbDrone.Core.Download.TrackedDownloads;
using NzbDrone.Core.MediaFiles;

// using NzbDrone.Core.MediaFiles.MovieImport;

namespace NzbDrone.Core.Download
{
    public interface ISeedboxFTPService
    {
        void Check(TrackedDownload trackedDownload);
    }

    public class SeedboxFTPService : ISeedboxFTPService
    {
        private readonly IProvideDownloadClient _downloadClientProvider;
        private readonly IDownloadedMovieImportService _downloadedMovieImportService;

        // private readonly FtpClient _ftpClient;
        private readonly ConcurrentDictionary<TrackedDownload, Task<bool>> _downloadTasks;

        public SeedboxFTPService(
            IProvideDownloadClient downloadClientProvider, IDownloadedMovieImportService downloadedMovieImportService)
        {
            _downloadClientProvider = downloadClientProvider;
            _downloadedMovieImportService = downloadedMovieImportService;
            _downloadTasks = new ConcurrentDictionary<TrackedDownload, Task<bool>>();
        }

        public void Check(TrackedDownload trackedDownload)
        {
            var downloadClient = _downloadClientProvider.Get(trackedDownload.DownloadClient);
            var definition = (DownloadClientDefinition)downloadClient.Definition;

            if ((trackedDownload.DownloadItem.Status != DownloadItemStatus.Completed)
                || !definition.SeedboxEnabled)
            {
                // Nothing to do in case the Download Item is not finished
                // this should be covered by CompletedDownloadService, but it doesnt hurt to check again
                return;
            }

            var outputPath = trackedDownload.DownloadItem.OutputPath;
            var localPath = trackedDownload.RemoteMovie.Movie.Path;

            // var importResults = _downloadedMovieImportService.ProcessPath(outputPath,
            //    ImportMode.Auto,
            //    trackedDownload.RemoteMovie.Movie,
            //    trackedDownload.ImportItem);

            /*
            if (_downloadTasks.IsEmpty)
            {
                InitializeFtpClient(definition);
            }
            */

            if (definition.SeedboxEnabled)
            {
                if (!_downloadTasks.TryGetValue(trackedDownload, out var existingTask))
                {
                    // Task downloadTask = StartFtpDownload(trackedDownload, definition);
                    return;
                }

                // so precisa baixar do ftp com o downloadpath pro movie.path que ta dentro do trackedDownload.Movie
            }

            return;
        }

        /* private void InitializeFtpClient(DownloadClientDefinition definition)
        {

            // _ftpClient = new FtpClient()
            return;
        }

        private async Task StartFtpDownload(TrackedDownload trackedDownload, DownloadClientDefinition downloadClientDefinition)
        {
            return null;
        }
        */
    }
}
