using FluentMigrator;
using NzbDrone.Core.Datastore.Migration.Framework;

namespace NzbDrone.Core.Datastore.Migration
{
    [Migration(241)]
    public class _241_add_seedbox_columns_to_download_client : NzbDroneMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("DownloadClients").AddColumn("SeedboxEnabled").AsBoolean();
            Alter.Table("DownloadClients").AddColumn("SeedboxFTPHost").AsString().Nullable();
            Alter.Table("DownloadClients").AddColumn("SeedboxFTPUser").AsString().Nullable();
            Alter.Table("DownloadClients").AddColumn("SeedboxFTPPassword").AsString().Nullable();
        }
    }
}
