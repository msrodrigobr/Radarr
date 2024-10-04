namespace NzbDrone.Core.Download
{
    public enum DownloadItemStatus
    {
        Queued = 0,
        Paused = 1,
        Downloading = 2,
        Completed = 3,
        Downloading_Seedbox = 6,
        Completed_Seedbox = 7,
        Failed = 4,
        Warning = 5
    }
}
