using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NilkanthApplication.Classes
{
    public class PlcJson
    {
        [JsonProperty("production_date")]
        public string ProductionDate { get; set; }

        [JsonProperty("production_time")]
        public string ProductionTime { get; set; }

        [JsonProperty("batch_number")]
        public int BatchNumber { get; set; }

        [JsonProperty("cycle")]
        public int Cycle { get; set; }

        [JsonProperty("recipe_name")]
        public string RecipeName { get; set; }

        [JsonProperty("truck_number")]
        public string TruckNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }

        [JsonProperty("driver_name")]
        public string DriverName { get; set; }

        [JsonProperty("batch_capacity")]
        public decimal BatchCapacity { get; set; }

        [JsonProperty("set_cycle")]
        public int SetCycle { get; set; }

        [JsonProperty("set_aggregation_1")]
        public decimal SetAggregation1 { get; set; }

        [JsonProperty("aggregation_1")]
        public decimal Aggregation1 { get; set; }

        [JsonProperty("set_aggregation_2")]
        public decimal SetAggregation2 { get; set; }

        [JsonProperty("aggregation_2")]
        public decimal Aggregation2 { get; set; }

        [JsonProperty("set_aggregation_3")]
        public decimal SetAggregation3 { get; set; }

        [JsonProperty("aggregation_3")]
        public decimal Aggregation3 { get; set; }

        [JsonProperty("set_aggregation_4")]
        public decimal SetAggregation4 { get; set; }

        [JsonProperty("aggregation_4")]
        public decimal Aggregation4 { get; set; }

        [JsonProperty("set_cement")]
        public decimal SetCement { get; set; }

        [JsonProperty("cement")]
        public decimal Cement { get; set; }

        [JsonProperty("set_flyash")]
        public decimal SetFlyash { get; set; }

        [JsonProperty("flyash")]
        public decimal Flyash { get; set; }

        [JsonProperty("set_water")]
        public decimal SetWater { get; set; }

        [JsonProperty("water")]
        public decimal Water { get; set; }

        [JsonProperty("set_admixture")]
        public decimal SetAdmixture { get; set; }

        [JsonProperty("admixture")]
        public decimal Admixture { get; set; }

        [JsonProperty("set_silica")]
        public decimal SetSilica { get; set; }

        [JsonProperty("silica")]
        public decimal Silica { get; set; }

        [JsonProperty("set_ggbs")]
        public decimal SetGgbs { get; set; }

        [JsonProperty("ggbs")]
        public decimal Ggbs { get; set; }

        [JsonProperty("total_actual")]
        public decimal TotalActual { get; set; }

        public int Id { get; set; }
    }

}
