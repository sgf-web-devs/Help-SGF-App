using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Algolia.Search;
using HelpSGF.Models;
using HelpSGF.Models.Search;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCLAppConfig;

namespace HelpSGF.Services
{
    public class DataService : IDisposable
    {
        static HttpClient httpClient = new HttpClient();
        public ObservableCollection<Location> Locations { get; set; }
        public ObservableCollection<LocationSearchResultItem> LocationSearchResultItems { get; set; }
        public static string AlgoliaApplicationID = "";
        public static string AlgoliaApiKey = "";
        public static string AlgoliaIndex = "";
        public static string HelpSGFAPIRoot = "";

        private AlgoliaClient _client;
        private Index _index;
        public DataService()
        {
            if(ConfigurationManager.AppSettings != null)
            {
                AlgoliaApplicationID = ConfigurationManager.AppSettings["algolia.applicationId"];
                AlgoliaApiKey = ConfigurationManager.AppSettings["algolia.apiKey"];
                AlgoliaIndex = ConfigurationManager.AppSettings["algolia.index"];
                HelpSGFAPIRoot = ConfigurationManager.AppSettings["helpsgf.apiroot"];
            }

            _client = new AlgoliaClient(AlgoliaApplicationID, AlgoliaApiKey);
            _index = _client.InitIndex(AlgoliaIndex);
        }

        public Dictionary<string, Dictionary<string, int>> GetFacets()
        {
            var query = new Query("");
            query.SetNbHitsPerPage(0);
            query.SetFacets(new List<string> {"categories.lvl0", "categories.lvl1" });
            var res = _index.Search(query);
            var results = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(res["facets"].ToString());

            return results;
        }

        public ObservableCollection<LocationSearchResultItem> GetLocations()
        {
            var i = 0;

            var res = _index.Search(new Query("food"));
            var count = res.Count;
            var results = JsonConvert.DeserializeObject<List<LocationSearchResultItem>>(res["hits"].ToString());


            LocationSearchResultItems = new ObservableCollection<LocationSearchResultItem>();

            var locations = new List<LocationSearchResultItem>
            {
                new LocationSearchResultItem { Name = "Location 1", Description = "Description for location 1" },
                new LocationSearchResultItem { Name = "Location 2", Description = "Description for location 2" }
            };

            Locations.Clear();

            foreach (var location in results)
            {
                i++;
                location.Index = i;
                LocationSearchResultItems.Add(location);
            }

            return LocationSearchResultItems;
        }

        public ObservableCollection<LocationSearchResultItem> SearchLocations(string searchText)
        {
            var i = 0;


            var res = _index.Search(new Query(searchText));

            var count = res.Count;
            var results = JsonConvert.DeserializeObject<List<LocationSearchResultItem>>(res["hits"].ToString());

            LocationSearchResultItems = new ObservableCollection<LocationSearchResultItem>();

            //Locations.Clear();

            foreach (var location in results)
            {
                i++;
                location.Index = i;
                LocationSearchResultItems.Add(location);
            }

            return LocationSearchResultItems;
        }

        public ObservableCollection<LocationSearchResultItem> FilterLocations(string subCategory)
        {
            var i = 0;


            var query = new Query();
            query.SetFacetFilters(new string[] { "categories.lvl1:" + subCategory });

            var res = _index.Search(query);

            var count = res.Count;
            var results = JsonConvert.DeserializeObject<List<LocationSearchResultItem>>(res["hits"].ToString());

            LocationSearchResultItems = new ObservableCollection<LocationSearchResultItem>();

            //Locations.Clear();

            foreach (var location in results)
            {
                i++;
                location.Index = i;
                LocationSearchResultItems.Add(location);
            }

            return LocationSearchResultItems;
        }

        public async Task<Location> GetLocationAsync(string urlPath)
        {
            var location = new Location();
            var path = HelpSGFAPIRoot + urlPath + "json";

            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //location = await response.Content.ReadAsStringAsync<Location>();
                var json = await response.Content.ReadAsStringAsync();

                location = JsonConvert.DeserializeObject<Location>(json);

                return location;
            }

            return null;
        }

        public async Task<List<MainCategory>> GetMainCategoriesAsync()
        {
            var path = HelpSGFAPIRoot + "/Umbraco/Api/API/GetMainCategories";
            HttpResponseMessage response = await httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var categories = JsonConvert.DeserializeObject<List<MainCategory>>(json);

                return categories;
            }

            return null;
        }

        public void Dispose()
        {

        }
    }
}
