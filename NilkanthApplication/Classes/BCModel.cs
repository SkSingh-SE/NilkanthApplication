using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BCAPIConnectivity.Classes
{
    public class BCModel
    {

    }

    public class Company
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class OData<T>
    {
        [JsonProperty("odata.context")]
        public string Metadata { get; set; }
        public T value { get; set; }
    }

    public class Item
    {
        public string No { get; set; }
        public string Description { get; set; }
    }

}
