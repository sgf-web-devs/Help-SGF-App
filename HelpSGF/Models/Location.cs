using System;
using Newtonsoft.Json;

namespace HelpSGF.Models
{
    public class Location
    {
        [JsonProperty("objectID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        //[JsonProperty("formatted_address")]
        //public string FormattedAddress { get; set; }

        private string formattedAddress;

        [JsonProperty("formatted_address")]
        public string FormattedAddress {
            get
            {
                ///return FormattedAddress.Replace(", USA", "");
                return formattedAddress.Replace(", USA", "");
            }

            set
            {
                formattedAddress = value;
            }
        }


        public string KeyedInAddressHash { get; set; }
        [JsonProperty("nice_url")]
        public string NiceURL { get; set; }
        [JsonProperty("service_types")]
        public string[] ServiceTypes { get; set; }
    }
}
