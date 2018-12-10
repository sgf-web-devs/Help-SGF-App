using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Algolia.Search;
using HelpSGF.Models;
using Newtonsoft.Json;

namespace HelpSGF.Services
{
    public class DataService
    {
        public ObservableCollection<Location> Locations { get; set; }

        public DataService()
        {
        }

        public ObservableCollection<Location> GetLocations()
        {
            //List<Location> locations = new List<Location>();
            AlgoliaClient client = new AlgoliaClient("ZK2OLFIMQP", "781ea64211b8349e8ddb934ba33513d5");
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
    }
}
