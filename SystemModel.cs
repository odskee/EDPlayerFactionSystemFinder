using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlayerFactionSystemFinder
{
    public partial class SystemWelcome
    {
        [JsonProperty("docs", NullValueHandling = NullValueHandling.Ignore)]
        public List<SystemDoc> Docs { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Limit { get; set; }

        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public int Page { get; set; }

        [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
        public int Pages { get; set; }

        [JsonProperty("pagingCounter", NullValueHandling = NullValueHandling.Ignore)]
        public long? PagingCounter { get; set; }

        [JsonProperty("hasPrevPage", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasPrevPage { get; set; }

        [JsonProperty("hasNextPage", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasNextPage { get; set; }

        [JsonProperty("prevPage")]
        public object PrevPage { get; set; }

        [JsonProperty("nextPage", NullValueHandling = NullValueHandling.Ignore)]
        public long? NextPage { get; set; }
    }

    public partial class SystemDoc
    {
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("__v", NullValueHandling = NullValueHandling.Ignore)]
        public long? V { get; set; }

        [JsonProperty("allegiance", NullValueHandling = NullValueHandling.Ignore)]
        public string Allegiance { get; set; }

        [JsonProperty("conflicts", NullValueHandling = NullValueHandling.Ignore)]
        public List<SystemConflict> Conflicts { get; set; }

        [JsonProperty("controlling_minor_faction", NullValueHandling = NullValueHandling.Ignore)]
        public string ControllingMinorFaction { get; set; }

        [JsonProperty("controlling_minor_faction_cased", NullValueHandling = NullValueHandling.Ignore)]
        public string ControllingMinorFactionCased { get; set; }

        [JsonProperty("controlling_minor_faction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ControllingMinorFactionId { get; set; }

        [JsonProperty("eddb_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? EddbId { get; set; }

        [JsonProperty("factions", NullValueHandling = NullValueHandling.Ignore)]
        public List<FactionElement> Factions { get; set; }

        [JsonProperty("government", NullValueHandling = NullValueHandling.Ignore)]
        public string Government { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("name_lower", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLower { get; set; }

        [JsonProperty("population", NullValueHandling = NullValueHandling.Ignore)]
        public long? Population { get; set; }

        [JsonProperty("primary_economy", NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryEconomy { get; set; }

        [JsonProperty("secondary_economy", NullValueHandling = NullValueHandling.Ignore)]
        public string SecondaryEconomy { get; set; }

        [JsonProperty("security", NullValueHandling = NullValueHandling.Ignore)]
        public string Security { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("system_address", NullValueHandling = NullValueHandling.Ignore)]
        public string SystemAddress { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public double? X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public double? Y { get; set; }

        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
        public double? Z { get; set; }

        [JsonProperty("name_aliases", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> NameAliases { get; set; }

        [JsonProperty("distanceFromReferenceSystem", NullValueHandling = NullValueHandling.Ignore)]
        public double? DistanceFromReferenceSystem { get; set; }
    }

    public partial class SystemConflict
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("faction1", NullValueHandling = NullValueHandling.Ignore)]
        public Faction1Class Faction1 { get; set; }

        [JsonProperty("faction2", NullValueHandling = NullValueHandling.Ignore)]
        public Faction1Class Faction2 { get; set; }
    }

    public partial class Faction1Class
    {
        [JsonProperty("faction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FactionId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("name_lower", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLower { get; set; }

        [JsonProperty("station_id")]
        public string StationId { get; set; }

        [JsonProperty("stake", NullValueHandling = NullValueHandling.Ignore)]
        public string Stake { get; set; }

        [JsonProperty("stake_lower", NullValueHandling = NullValueHandling.Ignore)]
        public string StakeLower { get; set; }

        [JsonProperty("days_won", NullValueHandling = NullValueHandling.Ignore)]
        public long? DaysWon { get; set; }
    }

    public partial class FactionElement
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("name_lower", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLower { get; set; }

        [JsonProperty("faction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FactionId { get; set; }
    }
}
