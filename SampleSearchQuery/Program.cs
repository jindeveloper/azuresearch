using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSearchQuery
{
    class Program
    {
        static string searchServiceName = ConfigurationManager.AppSettings["SearchName"];
        static string apiKey = ConfigurationManager.AppSettings["APIKey"];
        static string queryKey = ConfigurationManager.AppSettings["QueryAPIKey"];

        static void Main(string[] args)
        {
            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));

            SearchIndexClient queryClient =
                    new SearchIndexClient(searchServiceName,
                                "accounts", new SearchCredentials(apiKey));

            DocumentSearchResult<Account> results;

            SearchParameters parameters = new SearchParameters
            {

                Filter = "age lt 45",
                Select = new[] { "age","lastName", "firstName" }

            };

            //results = queryClient.Documents.Search<Account>("Hughes", parameters);
            results = queryClient.Documents.Search<Account>("*", parameters);
        }
    }
}
