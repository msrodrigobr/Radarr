namespace NzbDrone.Core.Download
{
    public enum DownloadItemStatus
    {
        Queued = 0,
        Paused = 1,
        Downloading = 2,
        SeedboxDownloading = 6,
        Completed = 3,
        SeedboxCompleted = 7,
        Failed = 4,
        Warning = 5
    }
}
