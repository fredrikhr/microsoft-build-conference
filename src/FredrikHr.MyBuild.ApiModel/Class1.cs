using System;

using Newtonsoft.Json;

using THNETII.Common;

namespace FredrikHr.MyBuild.ApiModel
{
    public class ProfileInformation
    {
        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("profileIdentity")]
        public ProfileIdentity ProfileIdentity { get; set; } = null!;
        [JsonProperty("registrationDetail")]
        public RegistrationDetail RegistrationDetail { get; set; } = null!;
        [JsonProperty("detail")]
        public ProfileDetail Detail { get; set; } = null!;
        [JsonProperty("optins")]
        public ProfileOptins Optins { get; set; } = null!;
        [JsonProperty("social")]
        public ProfileSocialInformation Social { get; set; } = null!;
        [JsonProperty("contacts")]
        public ProfileContactInformation Contacts { get; set; } = null!;
        [JsonProperty("attendeeType")]
        public AttendeeInformation AttendeeType { get; set; } = null!;
        #region public Version Version { get; set; } = null!;
        private readonly DuplexConversionTuple<ProfileInformationVersion, Version> version =
            new DuplexConversionTuple<ProfileInformationVersion, Version>(
                rawConvert: info => info.Value switch
                    {
                        0 => null,
                        int value => new Version(value, 0),
                    },
                rawEquals: (left, right) => left.Value == right.Value,
                rawReverseConvert: version => new ProfileInformationVersion { Value = version?.Major ?? 0 }
                );
        [JsonProperty("version")]
        public ProfileInformationVersion VersionStruct
        {
            get => version.RawValue;
            set => version.RawValue = value;
        }

        [JsonIgnore]
        public Version Version
        {
            get => version.ConvertedValue;
            set => version.ConvertedValue = value;
        }
        #endregion
        [JsonProperty("linkedIn")]
        public LinkedIdProfileReference LinkedIn { get; set; }
    }

    public class ProfileIdentity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("oid")]
        public string Oid { get; set; }
        [JsonProperty("isEmpty")]
        public bool IsEmpty { get; set; }
    }

    public class RegistrationDetail
    {
        private readonly DuplexConversionTuple<RegistrationStatusValue, RegistrationStatus> status =
            new DuplexConversionTuple<RegistrationStatusValue, RegistrationStatus>(
                rawConvert: v => (RegistrationStatus)v.Id,
                rawEquals: (l, r) => l.Id == r.Id,
                rawReverseConvert: v => new RegistrationStatusValue { Id = (int)v, Name = v.ToString() }
                );
        [JsonProperty("status")]
        public RegistrationStatusValue StatusStruct
        {
            get => status.RawValue;
            set => status.RawValue = value;
        }
        [JsonIgnore]
        public RegistrationStatus Status
        {
            get => status.ConvertedValue;
            set => status.ConvertedValue = value;
        }
        [JsonIgnore]
        public string StatusName => StatusStruct.Name;
        [JsonProperty("isRegistered")]
        public bool IsRegistered { get; set; }
        [JsonProperty("canBeIndexed")]
        public bool CanBeIndexed { get; set; }
    }

    public struct RegistrationStatusValue : IEquatable<RegistrationStatusValue>, IEquatable<RegistrationStatus>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public override bool Equals(object obj) => obj switch
        {
            string n => string.Equals(Name, n, StringComparison.Ordinal),
            RegistrationStatus st => Equals(st),
            RegistrationStatusValue v => Equals(v),
            _ => false,
        };

        public bool Equals(RegistrationStatusValue other) =>
            Id == other.Id && string.Equals(Name, other.Name, StringComparison.Ordinal);

        public bool Equals(RegistrationStatus other) => Id == (int)other;

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(
            RegistrationStatusValue left, RegistrationStatusValue right) =>
            left.Equals(right);

        public static bool operator ==(
            RegistrationStatusValue left, RegistrationStatus right) =>
            left.Equals(right);

        public static bool operator ==(
            RegistrationStatus left, RegistrationStatusValue right) =>
            right.Equals(left);

        public static bool operator !=(
            RegistrationStatusValue left, RegistrationStatusValue right) =>
            !(left == right);

        public static bool operator !=(
            RegistrationStatusValue left, RegistrationStatus right) =>
            !(left == right);

        public static bool operator !=(
            RegistrationStatus left, RegistrationStatusValue right) =>
            !(left == right);
    }

    public enum RegistrationStatus : int
    {
        Unknown = 0,
        Registered = 2,
    }

    public class ProfileDetail
    {
        [JsonProperty("genderPronouns")]
        public string GenderPronouns { get; set; }
        [JsonProperty("languagesSpoken")]
        public string LanguagesSpoken { get; set; }
        [JsonProperty("area")]
        public string Area { get; set; }
        [JsonProperty("jobCategory")]
        public JobCategory JobCategory { get; set; }
        [JsonProperty("communities")]
        public object Communities { get; set; }
        [JsonProperty("jobRoleOther")]
        public object JobRoleOther { get; set; }
        [JsonProperty("businessCountry")]
        public object BusinessCountry { get; set; }
        [JsonProperty("industryOther")]
        public object IndustryOther { get; set; }
        [JsonProperty("jobCategoryOfInterest")]
        public object JobCategoryOfInterest { get; set; }
        [JsonProperty("productsUsed")]
        public object ProductsUsed { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("b2BUserName")]
        public object B2BUserName { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("areaCountry")]
        public object AreaCountry { get; set; }
        [JsonProperty("profileImage")]
        public string ProfileImage { get; set; }
        [JsonProperty("biography")]
        public string Biography { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("firstLoggedIn")]
        public DateTimeOffset FirstLoggedIn { get; set; }
        [JsonProperty("lastLoggedIn")]
        public DateTimeOffset LastLoggedIn { get; set; }
        [JsonProperty("jobRole")]
        public object JobRole { get; set; }
        [JsonProperty("industry")]
        public object Industry { get; set; }
        [JsonProperty("topicsOfInterest")]
        public object TopicsOfInterest { get; set; }
        [JsonProperty("productsOfInterest")]
        public object ProductsOfInterest { get; set; }
    }

    public class JobCategory
    {
        [JsonProperty("key")]
        public object Key { get; set; }
        [JsonProperty("value")]
        public object Value { get; set; }
    }

    public class ProfileOptins
    {
        [JsonProperty("hasLoggedOn")]
        public bool HasLoggedOn { get; set; }
        [JsonProperty("canBeFound")]
        public bool CanBeFound { get; set; }
        [JsonProperty("canShareSessions")]
        public bool CanShareSessions { get; set; }
        [JsonProperty("isPubliclyVisible")]
        public bool IsPubliclyVisible { get; set; }
        [JsonProperty("canAccessMyEnvision")]
        public bool CanAccessMyEnvision { get; set; }
        [JsonProperty("canAttendMeetings")]
        public bool CanAttendMeetings { get; set; }
        [JsonProperty("canSendToCalendar")]
        public bool CanSendToCalendar { get; set; }
        [JsonProperty("canAccessExpertConnect")]
        public bool CanAccessExpertConnect { get; set; }
        [JsonProperty("doNotSendToCalendarMeetingAppointments")]
        public bool DoNotSendToCalendarMeetingAppointments { get; set; }
        [JsonProperty("doNotSendToCalendarSessions")]
        public bool DoNotSendToCalendarSessions { get; set; }
    }

    public class ProfileSocialInformation
    {
        [JsonProperty("facebook")]
        public string Facebook { get; set; }
        [JsonProperty("linkedIn")]
        public string LinkedIn { get; set; }
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("blog")]
        public string Blog { get; set; }
    }

    public class ProfileContactInformation
    {
        [JsonProperty("authentication")]
        public string Authentication { get; set; }
        [JsonProperty("notification")]
        public string Notification { get; set; }
    }

    public class AttendeeInformation
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("isEmpty")]
        public bool IsEmpty { get; set; }
        [JsonProperty("isSpeaker")]
        public bool IsSpeaker { get; set; }
        [JsonProperty("isAnonymous")]
        public bool IsAnonymous { get; set; }
        [JsonProperty("isRemote")]
        public bool IsRemote { get; set; }
        [JsonProperty("isTef")]
        public bool IsTef { get; set; }
    }

    public struct ProfileInformationVersion :
        IEquatable<ProfileInformationVersion>, IEquatable<Version>,
        IComparable, IComparable<ProfileInformationVersion>, IComparable<Version>
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        public override bool Equals(object obj) => obj switch
        {
            int v => Equals(v),
            Version ver => Equals(ver),
            ProfileInformationVersion ver => Equals(ver),
            _ => false,
        };

        public bool Equals(ProfileInformationVersion other) =>
            Value == other.Value;

        public bool Equals(Version other) =>
            !(other is null) && Value == other.Major;

        public int CompareTo(object other) => other switch
        {
            int v => Value.CompareTo(v),
            Version ver => Value.CompareTo(ver.Major),
            ProfileInformationVersion ver => Value.CompareTo(ver),
            _ => -1,
        };

        public int CompareTo(ProfileInformationVersion other) =>
            Value.CompareTo(other.Value);

        public int CompareTo(Version other) =>
            other is null ? -1 : Value.CompareTo(other.Major);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(
            ProfileInformationVersion left, ProfileInformationVersion right) =>
            left.Equals(right);

        public static bool operator ==(
            ProfileInformationVersion left, Version right) =>
            left.Equals(right);

        public static bool operator ==(
            Version left, ProfileInformationVersion right) =>
            right.Equals(left);

        public static bool operator !=(
            ProfileInformationVersion left, ProfileInformationVersion right) =>
            !left.Equals(right);

        public static bool operator !=(
            ProfileInformationVersion left, Version right) =>
            !left.Equals(right);

        public static bool operator !=(
            Version left, ProfileInformationVersion right) =>
            !right.Equals(left);

        public static bool operator <(
            ProfileInformationVersion left, ProfileInformationVersion right) =>
            left.CompareTo(right) < 0;

        public static bool operator <(
            ProfileInformationVersion left, Version right) =>
            left.CompareTo(right) < 0;

        public static bool operator <(
            Version left, ProfileInformationVersion right) =>
            right.CompareTo(left) > 0;

        public static bool operator <=(
            ProfileInformationVersion left, ProfileInformationVersion right) =>
            left.CompareTo(right) <= 0;

        public static bool operator <=(
            ProfileInformationVersion left, Version right) =>
            left.CompareTo(right) <= 0;

        public static bool operator <=(
            Version left, ProfileInformationVersion right) =>
            right.CompareTo(left) >= 0;

        public static bool operator >(
            ProfileInformationVersion left, ProfileInformationVersion right) =>
            left.CompareTo(right) > 0;

        public static bool operator >(
            ProfileInformationVersion left, Version right) =>
            left.CompareTo(right) > 0;

        public static bool operator >(
            Version left, ProfileInformationVersion right) =>
            right.CompareTo(left) < 0;

        public static bool operator >=(
            ProfileInformationVersion left, ProfileInformationVersion right) =>
            left.CompareTo(right) >= 0;

        public static bool operator >=(
            ProfileInformationVersion left, Version right) =>
            left.CompareTo(right) >= 0;

        public static bool operator >=(
            Version left, ProfileInformationVersion right) =>
            right.CompareTo(left) >= 0;
    }

    public class LinkedIdProfileReference
    {
        [JsonProperty("profileId")]
        public string ProfileId { get; set; }
        [JsonProperty("picturePath")]
        public string PicturePath { get; set; }
        [JsonProperty("profilePath")]
        public string ProfilePath { get; set; }
    }
}
