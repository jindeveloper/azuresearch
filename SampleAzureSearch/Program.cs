using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace SampleAzureSearch
{
    class Program
    {
        static string searchServiceName = ConfigurationManager.AppSettings["SearchName"];
        static string apiKey = ConfigurationManager.AppSettings["APIKey"];
        static string queryKey = ConfigurationManager.AppSettings["QueryAPIKey"];

        static void Main(string[] args)
        {
            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName,
                            new SearchCredentials(apiKey));

            if (serviceClient.Indexers.Exists("accounts"))
                serviceClient.Indexers.Delete("accounts");


            var accountIndexDefinition = new Index()
            {
 
                Name = "accounts",
                Fields = FieldBuilder.BuildForType<Account>(),

            };

            serviceClient.Indexes.Create(accountIndexDefinition);

            ISearchIndexClient indexClient = serviceClient.Indexes.GetClient("accounts");

            ImportDocument(indexClient);

        }

        private static void ImportDocument(ISearchIndexClient indexClient)
        {
            var actions = new List<IndexAction<Account>>();

            string line = string.Empty;

            using (var file = new StreamReader("accounts.json"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    JObject json = JObject.Parse(line);
                    Account account = json.ToObject<Account>();

                    actions.Add(IndexAction.Upload(account));
                }

                file.Close();
            }

            var batch = IndexBatch.New(actions);

            try
            {
                indexClient.Documents.Index(batch);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
