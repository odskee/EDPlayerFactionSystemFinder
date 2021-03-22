using Newtonsoft.Json;
namespace PlayerFactionSystemFinder
{
    public partial class EddbModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpdatedAt { get; set; }

        [JsonProperty("government_id")]
        public long? GovernmentId { get; set; }

        [JsonProperty("government")]
        public string Government { get; set; }

        [JsonProperty("allegiance_id")]
        public long? AllegianceId { get; set; }

        [JsonProperty("allegiance")]
        public string Allegiance { get; set; }

        [JsonProperty("home_system_id")]
        public long? HomeSystemId { get; set; }

        [JsonProperty("is_player_faction", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPlayerFaction { get; set; }
    }

    public enum EDDBAllegiance { Alliance, Empire, Federation, Independent, None, PilotsFederation };

    public enum Government { Anarchy, Communism, Confederacy, Cooperative, Corporate, Democracy, Dictatorship, Engineer, Feudal, None, Patronage, Prison, PrisonColony, Theocracy };
}
