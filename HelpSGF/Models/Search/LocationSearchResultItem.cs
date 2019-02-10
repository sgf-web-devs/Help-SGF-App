using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static HelpSGF.Utilities.JsonConverters;

namespace HelpSGF.Models.Search
{
    public class LocationSearchResultItem
    {
        [JsonProperty("objectID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CategoryResultCollection Categories { get; set; }
        public int Index { get; set; }

        //[JsonProperty("formatted_address")]
        //public string FormattedAddress { get; set; }

        private string formattedAddressPreview;

        [JsonProperty("formatted_address")]
        public string FormattedAddressPreview
        {
            get
            {
                ///return FormattedAddress.Replace(", USA", "");
                return formattedAddressPreview.Replace(", USA", "");
            }

            set
            {
                formattedAddressPreview = value;
            }
        }

        private string formattedAddress;
        [JsonProperty("formattedAddress")]
        public string FormattedAddress
        {
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


        public class CategoryResultCollection
        {
            [JsonConverter(typeof(SingleOrArrayConverter<string>))]
            public List<String> Lvl0 { get; set; }
            [JsonConverter(typeof(SingleOrArrayConverter<string>))]
            public List<String> Lvl1 { get; set; }
        }

    }

}
