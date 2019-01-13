using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Algolia.Search;
using HelpSGF.Models;
using Newtonsoft.Json;
using PCLAppConfig;

namespace HelpSGF.Services
{
    public class DataService
    {
        static HttpClient httpClient = new HttpClient();
        public ObservableCollection<Location> Locations { get; set; }

        public DataService()
        {
        }

        public ObservableCollection<Location> GetLocations()
        {
            var i = 0;
            //List<Location> locations = new List<Location>();
            AlgoliaClient client = new AlgoliaClient(ConfigurationManager.AppSettings["algolia.applicationId"], ConfigurationManager.AppSettings["algolia.apiKey"]);
            Index index = client.InitIndex("testing");

            var res = index.Search(new Query("food"));
            Console.WriteLine(res["hits"].ToString());
            var count = res.Count;
            var results = JsonConvert.DeserializeObject<List<Location>>(res["hits"].ToString());


            Locations = new ObservableCollection<Location>();

            var locations = new List<Location>
            {
                new Location { Name = "Location 1", Description = "Description for location 1" },
                new Location { Name = "Location 2", Description = "Description for location 2" }
            };

            Locations.Clear();

            foreach (var location in results)
            {
                i++;
                location.Index = i;
                Locations.Add(location);
            }

            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}


            return Locations;
        }

        public ObservableCollection<Location> SearchLocations(string searchText)
        {
            var i = 0;
            AlgoliaClient client = new AlgoliaClient(ConfigurationManager.AppSettings["algolia.applicationId"], ConfigurationManager.AppSettings["algolia.apiKey"]);
            Index index = client.InitIndex("testing");

            var res = index.Search(new Query(searchText));
            Console.WriteLine(res["hits"]);

            var count = res.Count;
            var results = JsonConvert.DeserializeObject<List<Location>>(res["hits"].ToString());

            Locations = new ObservableCollection<Location>();

            //Locations.Clear();

            foreach (var location in results)
            {
                i++;
                location.Index = i;
                Locations.Add(location);
            }

            return Locations;
        }

        public async Task<Location> GetLocationAsync(string urlPath)
        {
            var location = new Location();
            var path = "https://helpsgf.com" + urlPath + "json";

            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //location = await response.Content.ReadAsStringAsync<Location>();
                var json = await response.Content.ReadAsStringAsync();

                location = JsonConvert.DeserializeObject<Location>(json);

                var hey2 = location;
                return location;
            }

            return null;
        }
    }
}
