using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilkanthApplication.Classes
{
    public class BreakdownDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("model_no")]
        public string ModelNo { get; set; }

        [JsonProperty("serial_no")]
        public string SerialNo { get; set; }

        [JsonProperty("fault_start_date")]
        public string FaultStartDate { get; set; }

        [JsonProperty("fault_stop_date")]
        public string FaultStopDate { get; set; }

        [JsonProperty("incharge_name")]
        public string InchargeName { get; set; }

        [JsonProperty("engineer_name")]
        public string EngineerName { get; set; }

        [JsonProperty("engineer_mobile_no")]
        public string EngineerMobileNo { get; set; }

        [JsonProperty("fault_types")]
        public string FaultTypeNames { get; set; }

        [JsonProperty("actual_faults")]
        public string ActualFaultNames { get; set; }

        [JsonProperty("work_carried_out")]
        public string WorkCarriedOutNames { get; set; }
    }


}
