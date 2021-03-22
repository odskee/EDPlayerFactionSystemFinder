using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlayerFactionSystemFinder
{


    public partial class Welcome
    {
        [JsonProperty("docs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Doc> Docs { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Limit { get; set; }

        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public long? Page { get; set; }

        [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pages { get; set; }

        [JsonProperty("pagingCounter", NullValueHandling = NullValueHandling.Ignore)]
        public long? PagingCounter { get; set; }

        [JsonProperty("hasPrevPage", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasPrevPage { get; set; }

        [JsonProperty("hasNextPage", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasNextPage { get; set; }

        [JsonProperty("prevPage")]
        public object PrevPage { get; set; }

        [JsonProperty("nextPage")]
        public object NextPage { get; set; }
    }

    public partial class Doc
    {
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("__v", NullValueHandling = NullValueHandling.Ignore)]
        public long? V { get; set; }

        [JsonProperty("allegiance", NullValueHandling = NullValueHandling.Ignore)]
        public string Allegiance { get; set; }

        [JsonProperty("eddb_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? EddbId { get; set; }

        [JsonProperty("faction_presence", NullValueHandling = NullValueHandling.Ignore)]
        public List<FactionPresence> FactionPresence { get; set; }

        [JsonProperty("government", NullValueHandling = NullValueHandling.Ignore)]
        public string Government { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("name_lower", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLower { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public partial class FactionPresence
    {
        [JsonProperty("system_name", NullValueHandling = NullValueHandling.Ignore)]
        public string SystemName { get; set; }

        [JsonProperty("system_name_lower", NullValueHandling = NullValueHandling.Ignore)]
        public string SystemNameLower { get; set; }

        [JsonProperty("system_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SystemId { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("influence", NullValueHandling = NullValueHandling.Ignore)]
        public double? Influence { get; set; }

        [JsonProperty("happiness", NullValueHandling = NullValueHandling.Ignore)]
        public string Happiness { get; set; }

        [JsonProperty("active_states", NullValueHandling = NullValueHandling.Ignore)]
        public List<ActiveState> ActiveStates { get; set; }

        [JsonProperty("pending_states", NullValueHandling = NullValueHandling.Ignore)]
        public List<IngState> PendingStates { get; set; }

        [JsonProperty("recovering_states", NullValueHandling = NullValueHandling.Ignore)]
        public List<IngState> RecoveringStates { get; set; }

        [JsonProperty("conflicts", NullValueHandling = NullValueHandling.Ignore)]
        public List<Conflict> Conflicts { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public partial class ActiveState
    {
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
    }

    public partial class Conflict
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("opponent_name", NullValueHandling = NullValueHandling.Ignore)]
        public string OpponentName { get; set; }

        [JsonProperty("opponent_name_lower", NullValueHandling = NullValueHandling.Ignore)]
        public string OpponentNameLower { get; set; }

        [JsonProperty("opponent_faction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OpponentFactionId { get; set; }

        [JsonProperty("station_id")]
        public string StationId { get; set; }

        [JsonProperty("stake", NullValueHandling = NullValueHandling.Ignore)]
        public string Stake { get; set; }

        [JsonProperty("stake_lower", NullValueHandling = NullValueHandling.Ignore)]
        public string StakeLower { get; set; }

        [JsonProperty("days_won", NullValueHandling = NullValueHandling.Ignore)]
        public long? DaysWon { get; set; }
    }

    public partial class IngState
    {
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("trend", NullValueHandling = NullValueHandling.Ignore)]
        public long? Trend { get; set; }
    }

}
