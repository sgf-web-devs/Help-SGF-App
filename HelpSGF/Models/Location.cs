using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Index { get; set; }
        public List<ServiceTypeDetail> ServiceTypeDetails { get; set; }
        public List<Contact> contacts { get; set; }


        //[JsonProperty("formatted_address")]
        //public string FormattedAddress { get; set; }

        private string formattedAddressPreview;

        [JsonProperty("formatted_address")]
        public string FormattedAddressPreview {
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


        public string[] ServiceTypes { get; set; }

        public static implicit operator Location(Task<Location> v)
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceTypeDetail
    {
        public string ServiceType { get; set; }
        public string Detail { get; set; }
    }

    public class Contact
    {
        public string ContactType { get; set; }
        public string ContactData { get; set; }
    }

}
