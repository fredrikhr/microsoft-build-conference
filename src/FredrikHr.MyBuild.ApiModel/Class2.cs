using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

namespace FredrikHr.MyBuild.ApiModel
{
    [SuppressMessage("Design", "CA1056: Uri properties should not be strings", Justification = "Serialization")]
    public class ConferenceSettings
    {
        [JsonProperty("allowLogOn")]
        public bool AllowLogOn { get; set; }
        [JsonProperty("showSpeakerInformation")]
        public bool ShowSpeakerInformation { get; set; }
        [JsonProperty("enableSpeakerNavigation")]
        public bool EnableSpeakerNavigation { get; set; }
        [JsonProperty("hideForJune7Release")]
        public bool HideForJune7Release { get; set; }
        [JsonProperty("conferenceUtcOffsetHours")]
        public float ConferenceUtcOffsetHours { get; set; }
        [JsonProperty("kendoSchedulerTimeZone")]
        public string KendoSchedulerTimeZone { get; set; }
        [JsonProperty("eventStartDate")]
        public DateTimeOffset EventStartDate { get; set; }
        [JsonProperty("eventEndDate")]
        public DateTimeOffset EventEndDate { get; set; }
        [JsonProperty("businessStartTime")]
        public DateTime BusinessLocalStartTime { get; set; }
        [JsonIgnore]
        public DateTimeOffset BusinessStartTime => new DateTimeOffset(
            BusinessLocalStartTime,
            TimeSpan.FromHours(ConferenceUtcOffsetHours)
            );
        [JsonProperty("businessEndTime")]
        public DateTime BusinessLocalEndTime { get; set; }
        [JsonIgnore]
        public DateTimeOffset BusinessEndTime => new DateTimeOffset(
            BusinessLocalEndTime,
            TimeSpan.FromHours(ConferenceUtcOffsetHours)
            );
        [JsonProperty("schedulerTimes")]
        public List<ScheduleSpan> SchedulerTimes { get; } =
            new List<ScheduleSpan>();
        [JsonProperty("emptySlotMinimumSizeInMinutes")]
        public int EmptySlotMinimumSizeInMinutes { get; set; }
        [JsonIgnore]
        public TimeSpan EmptySlotMinimumSize
        {
            get => TimeSpan.FromMinutes(EmptySlotMinimumSizeInMinutes);
            set => EmptySlotMinimumSizeInMinutes = (int)(value.TotalMinutes);
        }
        [JsonProperty("evaluationQuestionDelimiter")]
        public string EvaluationQuestionDelimiter { get; set; }
        [JsonProperty("evaluationStart")]
        public DateTimeOffset EvaluationStart { get; set; }
        [JsonProperty("evaluationEnd")]
        public DateTimeOffset EvaluationEnd { get; set; }
        [JsonProperty("postConferenceEvaluationStart")]
        public DateTimeOffset PostConferenceEvaluationStart { get; set; }
        [JsonProperty("postConferenceEvaluationEnd")]
        public DateTimeOffset PostConferenceEvaluationEnd { get; set; }
        [JsonProperty("enableSessionDiscussions")]
        public bool EnableSessionDiscussions { get; set; }
        [JsonProperty("enableDiscussionTranslation")]
        public bool EnableDiscussionTranslation { get; set; }
        [JsonProperty("keynoteTypeNames")]
        public List<string> KeynoteTypeNames { get; } = new List<string>();
        [JsonProperty("showAvailableRsvp")]
        public bool ShowAvailableRsvp { get; set; }
        [JsonProperty("showAvailableRsvpSelector")]
        public bool ShowAvailableRsvpSelector { get; set; }
        [JsonProperty("showOnDemand")]
        public bool ShowOnDemand { get; set; }
        [JsonProperty("showOnDemandDate")]
        public DateTimeOffset ShowOnDemandDate { get; set; }
        [JsonProperty("certExamHours")]
        public List<object> CertificationExamHours { get; } = new List<object>();
        [JsonProperty("preDayRegistrationLink")]
        public string PreDayRegistrationLink { get; set; }
        [JsonProperty("labHours")]
        public List<ScheduleSpanExtended> LabHours { get; } = new List<ScheduleSpanExtended>();
        [JsonProperty("showAppointmentsInMySchedule")]
        public bool ShowAppointmentsInMySchedule { get; set; }
        [JsonProperty("showMeetingsInMySchedule")]
        public bool ShowMeetingsInMySchedule { get; set; }
        [JsonProperty("conferenceTimeZoneIdentifier")]
        public string ConferenceTimeZoneIdentifier { get; set; }
        [JsonIgnore]
        public TimeZoneInfo ConferenceTimeZone =>
            TimeZoneInfo.FindSystemTimeZoneById(ConferenceTimeZoneIdentifier);
        [JsonProperty("enableDaylightSavingFix")]
        public bool EnableDaylightSavingFix { get; set; }
        [JsonProperty("secondScreenWaitTimeInMinutesBeforeNavigatingBack")]
        public int SecondScreenWaitTimeInMinutesBeforeNavigatingBack { get; set; }
        [JsonIgnore]
        public TimeSpan SecondScreenWaitTimeBeforeNavigatingBack
        {
            get => TimeSpan.FromMinutes(SecondScreenWaitTimeInMinutesBeforeNavigatingBack);
            set => SecondScreenWaitTimeInMinutesBeforeNavigatingBack = (int)(value.TotalMinutes);
        }
        [JsonProperty("enableStarredSessionsFeature")]
        public bool EnableStarredSessionsFeature { get; set; }
        [JsonProperty("showEvaluations")]
        public bool ShowEvaluations { get; set; }
        [JsonProperty("showPreConferenceEvaluation")]
        public bool ShowPreConferenceEvaluation { get; set; }
        [JsonProperty("showPostConferenceEvaluation")]
        public bool ShowPostConferenceEvaluation { get; set; }
        [JsonProperty("preConferenceEvaluationLink")]
        public string PreConferenceEvaluationLink { get; set; }
        [JsonProperty("postConferenceEvaluationLink")]
        public string PostConferenceEvaluationLink { get; set; }
        [JsonProperty("showMobileApp")]
        public bool ShowMobileApp { get; set; }
        [JsonProperty("showExpertConnect")]
        public bool ShowExpertConnect { get; set; }
        [JsonProperty("evaluationStartOffsetMinutes")]
        public int EvaluationStartOffsetMinutes { get; set; }
        [JsonIgnore]
        public TimeSpan EvaluationStartOffset
        {
            get => TimeSpan.FromMinutes(EvaluationStartOffsetMinutes);
            set => EvaluationStartOffsetMinutes = (int)(value.TotalMinutes);
        }
        [JsonProperty("showSessionOverflow")]
        public bool ShowSessionOverflow { get; set; }
        [JsonProperty("labActiveStart")]
        public DateTimeOffset LabActiveStart { get; set; }
        [JsonProperty("labActiveEnd")]
        public DateTimeOffset LabActiveEnd { get; set; }
        [JsonProperty("isDateTestingEnabled")]
        public bool IsDateTestingEnabled { get; set; }
        [JsonProperty("testingDate")]
        public DateTimeOffset TestingDate { get; set; }
        [JsonProperty("showLearningPaths")]
        public bool ShowLearningPaths { get; set; }
        [JsonProperty("showLearningPathCarousel")]
        public bool ShowLearningPathCarousel { get; set; }
        [JsonProperty("allowSessionCatalog")]
        public bool AllowSessionCatalog { get; set; }
        [JsonProperty("useLegacyOnDemandContent")]
        public bool UseLegacyOnDemandContent { get; set; }
        [JsonProperty("addEuroDomainParameter")]
        public bool AddEuroDomainParameter { get; set; }
        [JsonProperty("forceCookieConsent")]
        public bool ForceCookieConsent { get; set; }
        [JsonProperty("gapDetection")]
        public List<ScheduleSpan> GapDetection { get; } =
            new List<ScheduleSpan>();
        [JsonProperty("showMaps")]
        public bool ShowMaps { get; set; }
        [JsonProperty("showLocations")]
        public bool ShowLocations { get; set; }
        [JsonProperty("showBot")]
        public bool ShowBot { get; set; }
        [JsonProperty("showExpertFinder")]
        public bool ShowExpertFinder { get; set; }
        [JsonProperty("showCertExams")]
        public bool ShowCertExams { get; set; }
        [JsonProperty("showRoomsAndTimesToAnonymousUsers")]
        public bool ShowRoomsAndTimesToAnonymousUsers { get; set; }
        [JsonProperty("showHolNav")]
        public bool ShowHandOnLabNav { get; set; }
        [JsonProperty("holExpiredMarkup")]
        public string HandOnLabExpiredMarkup { get; set; }
        [JsonProperty("addHolToCalendar")]
        public bool AddHandOnLabToCalendar { get; set; }
        [JsonProperty("capacityValidationSessionTypes")]
        public string CapacityValidationSessionTypes { get; set; }
        [JsonProperty("showSolutionAreas")]
        public bool ShowSolutionAreas { get; set; }
        [JsonProperty("showHomePageLiveStream")]
        public bool ShowHomePageLiveStream { get; set; }
        [JsonProperty("showLinkedInCommunity")]
        public bool ShowLinkedInCommunity { get; set; }
        [JsonProperty("showConferenceGuide")]
        public bool ShowConferenceGuide { get; set; }
        [JsonProperty("showDiversityMeetings")]
        public bool ShowDiversityMeetings { get; set; }
        [JsonProperty("messageDailySendLimit")]
        public int MessageDailySendLimit { get; set; }
        [JsonProperty("blacklistedTechCommunityAvatars")]
        public List<string> BlacklistedTechCommunityAvatars { get; } =
            new List<string>();
        [JsonProperty("showSendToCalendar")]
        public bool ShowSendToCalendar { get; set; }
        [JsonProperty("showDownloadToCalendar")]
        public bool ShowDownloadToCalendar { get; set; }
        [JsonProperty("homePageOrder")]
        public Dictionary<string, HomePageOrder> HomePageOrder { get; } =
            new Dictionary<string, HomePageOrder>(StringComparer.Ordinal);
        [JsonProperty("useInterpolatedDate")]
        public bool UseInterpolatedDate { get; set; }
        [JsonProperty("appleHidden")]
        public bool AppleHidden { get; set; }
        [JsonProperty("appleMobileLink")]
        public string AppleMobileLink { get; set; }
        [JsonProperty("androidHidden")]
        public bool AndroidHidden { get; set; }
        [JsonProperty("androidMobileLink")]
        public string AndroidMobileLink { get; set; }
        [JsonProperty("useSearchResultsViewMode")]
        public bool UseSearchResultsViewMode { get; set; }
        [JsonProperty("techCommunityIntegration")]
        public bool TechCommunityIntegration { get; set; }
        [JsonProperty("allowTechCommunityLogOn")]
        public bool AllowTechCommunityLogOn { get; set; }
        [JsonProperty("allowUnregisteredUserTechCommunityLogOn")]
        public bool AllowUnregisteredUserTechCommunityLogOn { get; set; }
        [JsonProperty("showMyIgniteNavBar")]
        public bool ShowMyIgniteNavBar { get; set; }
        [JsonProperty("attendeeMeetingCapacityLimit")]
        public int AttendeeMeetingCapacityLimit { get; set; }
        [JsonProperty("preDaySessionType")]
        public string PreDaySessionType { get; set; }
        [JsonProperty("handsOnLabSessionType")]
        public string HandsOnLabSessionType { get; set; }
        [JsonProperty("rsvpSessionTypes")]
        public List<string> RsvpSessionTypes { get; } = new List<string>();
        [JsonProperty("showSessionDateSelector")]
        public bool ShowSessionDateSelector { get; set; }
        [JsonProperty("showAttendees")]
        public bool ShowAttendees { get; set; }
        [JsonProperty("showMessaging")]
        public bool ShowMessaging { get; set; }
        [JsonProperty("showMeetings")]
        public bool ShowMeetings { get; set; }
        [JsonProperty("showMeetingsLinkInNavigation")]
        public bool ShowMeetingsLinkInNavigation { get; set; }
        [JsonProperty("meetingDetails")]
        public MeetingDetails MeetingDetails { get; set; }
        [JsonProperty("enableSessionCatalogDetailPageLink")]
        public bool EnableSessionCatalogDetailPageLink { get; set; }
        [JsonProperty("sessionCatalogViewMode")]
        public string SessionCatalogViewMode { get; set; }
        [JsonProperty("enableShareScheduleFeature")]
        public bool EnableShareScheduleFeature { get; set; }
        [JsonProperty("pubbleSsoEnabled")]
        public bool PubbleSsoEnabled { get; set; }
        [JsonProperty("pubbleAppId")]
        public string PubbleAppId { get; set; }
        [JsonProperty("pubbleTokenCookieName")]
        public string PubbleTokenCookieName { get; set; }
        [JsonProperty("showAttendeesHeaderMessage")]
        public bool ShowAttendeesHeaderMessage { get; set; }
        [JsonProperty("showSessionsHeaderMessage")]
        public bool ShowSessionsHeaderMessage { get; set; }
        [JsonProperty("showSpeakersHeaderMessage")]
        public bool ShowSpeakersHeaderMessage { get; set; }
        [JsonProperty("showSponsorsHeaderMessage")]
        public bool ShowSponsorsHeaderMessage { get; set; }
        [JsonProperty("showVideosHeaderMessage")]
        public bool ShowVideosHeaderMessage { get; set; }
        [JsonProperty("showLearningPathHeadingIntro")]
        public bool ShowLearningPathHeadingIntro { get; set; }
        [JsonProperty("showLearningPathPivots")]
        public bool ShowLearningPathPivots { get; set; }
        [JsonProperty("showSponsorRecommendations")]
        public bool ShowSponsorRecommendations { get; set; }
        [JsonProperty("showAttendeeRecommendations")]
        public bool ShowAttendeeRecommendations { get; set; }
        [JsonProperty("showSessionRecommendations")]
        public bool ShowSessionRecommendations { get; set; }
        [JsonProperty("showSpeakerRecommendations")]
        public bool ShowSpeakerRecommendations { get; set; }
        [JsonProperty("showSessionsPromotedContent")]
        public bool ShowSessionsPromotedContent { get; set; }
        [JsonProperty("relatedSessionGenerationMethod")]
        public string RelatedSessionGenerationMethod { get; set; }
        [JsonProperty("showFavoritedSponsorsToggle")]
        public bool ShowFavoritedSponsorsToggle { get; set; }
        [JsonProperty("showFavoritedAttendeeToggle")]
        public bool ShowFavoritedAttendeeToggle { get; set; }
        [JsonProperty("showSpeakersInSessionBlock")]
        public bool ShowSpeakersInSessionBlock { get; set; }
        [JsonProperty("showPanelists")]
        public bool ShowPanelists { get; set; }
        [JsonProperty("showSpeakerConnect")]
        public bool ShowSpeakerConnect { get; set; }
        [JsonProperty("sessionSubHeaderMessageAuthenticated")]
        public string SessionSubHeaderMessageAuthenticated { get; set; }
        [JsonProperty("sessionSubHeaderMessageAnonymous")]
        public string SessionSubHeaderMessageAnonymous { get; set; }
        [JsonProperty("passwordResetLink")]
        public string PasswordResetLink { get; set; }
        [JsonProperty("showMoreLearningPathsSidebarDetail")]
        public bool ShowMoreLearningPathsSidebarDetail { get; set; }
        [JsonProperty("conferenceLocation")]
        public string ConferenceLocation { get; set; }
        [JsonProperty("showVideoDownloaderLink")]
        public bool ShowVideoDownloaderLink { get; set; }
        [JsonProperty("showColoredSessionDateSelector")]
        public bool ShowColoredSessionDateSelector { get; set; }
        [JsonProperty("expertConnectMeetingLocation")]
        public string ExpertConnectMeetingLocation { get; set; }
        [JsonProperty("mobileAppInstructionalVideos")]
        public List<object> MobileAppInstructionalVideos { get; } =
            new List<object>();
        [JsonProperty("showSessionsPopularitySort")]
        public bool ShowSessionsPopularitySort { get; set; }
        [JsonProperty("sessionsPopularitySortIsDefault")]
        public bool SessionsPopularitySortIsDefault { get; set; }
        [JsonProperty("showVideosPopularitySort")]
        public bool ShowVideosPopularitySort { get; set; }
        [JsonProperty("videosPopularitySortIsDefault")]
        public bool VideosPopularitySortIsDefault { get; set; }
        [JsonProperty("deepMap")]
        public DeepMapSettings DeepMap { get; set; }
        [JsonProperty("communities")]
        public List<object> Communities { get; } = new List<object>();
        [JsonProperty("displayDateTimesAsLocal")]
        public bool DisplayDateTimesAsLocal { get; set; }
        [JsonProperty("showMeetingLocation")]
        public bool ShowMeetingLocation { get; set; }
        [JsonProperty("showSchedulingAssistant")]
        public bool ShowSchedulingAssistant { get; set; }
        [JsonProperty("defaultMeetingLocation")]
        public string DefaultMeetingLocation { get; set; }
        [JsonProperty("alternateMeetingDateRange")]
        public object AlternateMeetingDateRange { get; set; }
        [JsonProperty("sessionStaticContent")]
        public object SessionStaticContent { get; set; }
        [JsonProperty("publicEventUrl")]
        public string PublicEventUrl { get; set; }
        [JsonProperty("registrationUrlOverride")]
        public string RegistrationUrlOverride { get; set; }
        [JsonProperty("showSponsorPages")]
        public bool ShowSponsorPages { get; set; }
        [JsonProperty("announcementBar")]
        public AnnouncementBarSettings AnnouncementBar { get; set; }
        [JsonProperty("unstructuredMeetingTimeLimit")]
        public int UnstructuredMeetingTimeLimit { get; set; }
        [JsonProperty("sessionInteractionStartsMinutesBeforeStart")]
        public int SessionInteractionStartsMinutesBeforeStart { get; set; }
        [JsonIgnore]
        public TimeSpan BeforeSessionStartInteractionTime
        {
            get => TimeSpan.FromMinutes(SessionInteractionStartsMinutesBeforeStart);
            set => SessionInteractionStartsMinutesBeforeStart = (int)(value.TotalMinutes);
        }
        [JsonProperty("sessionInteractionStopsMinutesAfterEnd")]
        public int SessionInteractionStopsMinutesAfterEnd { get; set; }
        [JsonIgnore]
        public TimeSpan AfterSessionEndInteractionTime
        {
            get => TimeSpan.FromMinutes(SessionInteractionStopsMinutesAfterEnd);
            set => SessionInteractionStopsMinutesAfterEnd = (int)(value.TotalMinutes);
        }
        [JsonProperty("enableTeamsLiveEventFailover")]
        public bool EnableTeamsLiveEventFailover { get; set; }
        [JsonProperty("showCommunityConnection")]
        public bool ShowCommunityConnection { get; set; }
        [JsonProperty("showStudentZone")]
        public bool ShowStudentZone { get; set; }
        [JsonProperty("configRefreshInterval")]
        public int ConfigRefreshIntervalMinutes { get; set; }
        [JsonIgnore]
        public TimeSpan ConfigRefreshInterval
        {
            get => TimeSpan.FromMinutes(ConfigRefreshIntervalMinutes);
            set => ConfigRefreshIntervalMinutes = (int)(value.TotalMinutes);
        }
        [JsonProperty("showRegistrationButton")]
        public bool ShowRegistrationButton { get; set; }
    }

    public struct HomePageOrder : IEquatable<HomePageOrder>, IComparable,
        IComparable<HomePageOrder>, IComparable<(int order, bool enabled)>
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }

        public override bool Equals(object obj) => obj switch
        {
            Tuple<int, bool> tuple => Order == tuple.Item1 && Enabled == tuple.Item2,
            ValueTuple<int, bool> tuple => Order == tuple.Item1 && Enabled == tuple.Item2,
            HomePageOrder other => Equals(other),
            _ => false
        };

        public bool Equals(HomePageOrder other) =>
            Order == other.Order && Enabled == other.Enabled;

        public int CompareTo(object obj) => obj switch
        {
            Tuple<int, bool> tuple => CompareTo((tuple.Item1, tuple.Item2)),
            ValueTuple<int, bool> tuple => CompareTo(tuple),
            HomePageOrder other => CompareTo(other),
            _ => -1,
        };

        public int CompareTo(HomePageOrder other) =>
            CompareTo((other.Order, other.Enabled));

        public int CompareTo((int order, bool enabled) tuple)
        {
            return Order.CompareTo(tuple.order) switch
            {
                0 => Enabled.CompareTo(tuple.enabled),
                int cmp => cmp,
            };
        }

        public override int GetHashCode() => Order.GetHashCode();

        public static bool operator ==(
            HomePageOrder left, HomePageOrder right) => left.Equals(right);

        public static bool operator !=(
            HomePageOrder left, HomePageOrder right) => !left.Equals(right);

        public static bool operator <(
            HomePageOrder left, HomePageOrder right) =>
            left.CompareTo(right) < 0;

        public static bool operator <=(
            HomePageOrder left, HomePageOrder right) =>
            left.CompareTo(right) <= 0;

        public static bool operator >(
            HomePageOrder left, HomePageOrder right) =>
            left.CompareTo(right) > 0;

        public static bool operator >=(
            HomePageOrder left, HomePageOrder right) =>
            left.CompareTo(right) >= 0;
    }

    public class MeetingDetails
    {
        [JsonProperty("locations")]
        public List<object> Locations { get; } = new List<object>();
        [JsonProperty("times")]
        public List<ScheduleSpanExtended> Times { get; } =
            new List<ScheduleSpanExtended>();
    }

    [SuppressMessage("Design", "CA1056: Uri properties should not be strings", Justification = "Serialization")]
    public class DeepMapSettings
    {
        [JsonProperty("mapServiceUrl")]
        public string MapServiceUrl { get; set; }
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
    }

    public class AnnouncementBarSettings
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("hyperlink")]
        public string Hyperlink { get; set; }
        [JsonProperty("hyperlinkText")]
        public string HyperlinkText { get; set; }
    }

    public class ScheduleSpan
    {
        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }
        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }
    }

    public class ScheduleSpanExtended : ScheduleSpan
    {
        [JsonProperty("day")]
        public string Day { get; set; }
    }
}
