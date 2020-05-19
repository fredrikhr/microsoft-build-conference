using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

namespace FredrikHr.MyBuild.ApiModel
{

    [SuppressMessage("Design", "CA1056: Uri properties should not be strings", Justification = "Serialization")]
    public class SessionInformation
    {
        [JsonProperty("sessionType")]
        public string SessionType { get; set; }
        [JsonProperty("canUserModifySchedule")]
        public bool CanUserModifySchedule { get; set; }
        [JsonProperty("products")]
        public List<string> Products { get; } = new List<string>();
        [JsonProperty("SpeakerTypes")]
        public List<string> SpeakerTypes { get; } = new List<string>();
        [JsonProperty("isCapacityControlled")]
        public bool IsCapacityControlled { get; set; }
        [JsonProperty("rsvpOpensAt")]
        public DateTime RsvpOpensAt { get; set; }
        [JsonProperty("roomHasCapacity")]
        public bool RoomHasCapacity { get; set; }
        [JsonProperty("hasRsvpOpened")]
        public bool HasRsvpOpened { get; set; }
        [JsonProperty("hasRsvpClosed")]
        public bool HasRsvpClosed { get; set; }
        [JsonProperty("waitlistHasCapacity")]
        public bool WaitlistHasCapacity { get; set; }
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
        [JsonProperty("sessionInstanceId")]
        public string SessionInstanceId { get; set; }
        [JsonProperty("sessionCode")]
        public string SessionCode { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("roomId")]
        public string RoomId { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("startDateTime")]
        public DateTime StartDateTime { get; set; }
        [JsonProperty("endDateTime")]
        public DateTime EndDateTime { get; set; }
        [JsonProperty("level")]
        public string Level { get; set; }
        [JsonProperty("durationInMinutes")]
        public int DurationInMinutes { get; set; }
        [JsonProperty("isMandatory")]
        public bool IsMandatory { get; set; }
        [JsonProperty("speakerIds")]
        public List<string> SpeakerIds { get; } = new List<string>();
        [JsonProperty("speakerNames")]
        public List<string> SpeakerNames { get; } = new List<string>();
        [JsonProperty("speakerCompanies")]
        public List<string> SpeakerCompanies { get; } = new List<string>();
        [JsonProperty("panelistIds")]
        public List<object> PanelistIds { get; } = new List<object>();
        [JsonProperty("panelistNames")]
        public List<object> PanelistNames { get; } = new List<object>();
        [JsonProperty("panelistCompanies")]
        public List<object> PanelistCompanies { get; } = new List<object>();
        [JsonProperty("failoverVideoUrl")]
        public string FailoverVideoUrl { get; set; }
        [JsonProperty("mediusChatUrl")]
        public string MediusChatUrl { get; set; }
        [JsonProperty("pubbleAppId")]
        public string PubbleAppId { get; set; }
        [JsonProperty("ssr")]
        public string Ssr { get; set; }
    }

}
