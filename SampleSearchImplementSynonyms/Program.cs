using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSearchImplementSynonyms
{
    class Program
    {
        static string searchServiceName = ConfigurationManager.AppSettings["SearchName"];
        static string apiKey = ConfigurationManager.AppSettings["APIKey"];
        static string queryKey = ConfigurationManager.AppSettings["QueryAPIKey"];

        static void Main(string[] args)
        {
            SearchServiceClient client =
                new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));

            var accountSynonymMapping = new SynonymMap
            {
                Name = "city-state-synonym-map",
                Format = "solr",
                Synonyms = "cal,california,CA"
            };

            client.SynonymMaps.CreateOrUpdate(accountSynonymMapping);


        }
    }
}
