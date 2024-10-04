using System;
using Equ;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.ThingiProvider;
using NzbDrone.Core.Validation;

namespace NzbDrone.Core.Download.Clients
{
    public abstract class DownloadClientSettingsBase<TSettings> : IProviderConfig, IEquatable<TSettings>
        where TSettings : DownloadClientSettingsBase<TSettings>
    {
        private static readonly MemberwiseEqualityComparer<TSettings> Comparer = MemberwiseEqualityComparer<TSettings>.ByProperties;

        [FieldDefinition(97, Label = "DownloadClientIsSeedbox", Type = FieldType.Checkbox)]
        public bool IsSeedbox { get; set; }

        [FieldDefinition(98, Label = "DownloadClientFtpHost", Type = FieldType.Textbox)]
        public string FtpHost { get; set; }

        [FieldDefinition(99, Label = "DownloadClientFtpUsername", Type = FieldType.Textbox, Privacy = PrivacyLevel.UserName)]
        public string FtpUsername { get; set; }

        [FieldDefinition(100, Label = "DownloadClientFtpPassword", Type = FieldType.Password, Privacy = PrivacyLevel.Password)]
        public string FtpPassword { get; set; }

        public abstract NzbDroneValidationResult Validate();

        public bool Equals(TSettings other)
        {
            return Comparer.Equals(this as TSettings, other);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TSettings);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this as TSettings);
        }
    }
}
