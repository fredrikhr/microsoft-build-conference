using System;
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json;

namespace FredrikHr.MyBuild.ApiModel
{

    public class SearchResultWithFacets<TResult>
    {
        [JsonProperty("data")]
        public List<TResult> Results { get; } = new List<TResult>();
        [JsonProperty("facets")]
        public Dictionary<string, SearchResultFacet> Facets { get; } =
            new Dictionary<string, SearchResultFacet>(StringComparer.Ordinal);
        [JsonProperty("total")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Total { get; set; }
    }

    public class SearchResultFacet
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("facetName")]
        public string FacetName { get; set; }
        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; }
        [JsonProperty("filters")]
        public List<Filter> Filters { get; } = new List<Filter>();
    }

    public class Filter
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class SpeakerInformation
    {
        [JsonProperty("speakerId")]
        public Guid SpeakerId { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("bio")]
        public string Biography { get; set; }
        [JsonProperty("photo")]
        public string Photo { get; set; }
        [JsonProperty("staffingDetails")]
        public string StaffingDetails { get; set; }
        [JsonProperty("assignmentName")]
        public string AssignmentName { get; set; }
        [JsonProperty("assignmentType")]
        public string AssignmentType { get; set; }
        [JsonProperty("currentLocation")]
        public string CurrentLocation { get; set; }
        [JsonProperty("assignmentStart")]
        public DateTimeOffset AssignmentStart { get; set; }
        [JsonProperty("assignmentEnd")]
        public DateTimeOffset AssignmentEnd { get; set; }
        [JsonProperty("currentLocationOriginalSerial")]
        public string CurrentLocationOriginalSerial { get; set; }
        [JsonProperty("timeSlots")]
        public string TimeSlots { get; set; }
    }
}
