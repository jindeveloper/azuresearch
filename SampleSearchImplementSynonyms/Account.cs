using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System.ComponentModel.DataAnnotations;

namespace SampleSearchImplementSynonyms
{
    [SerializePropertyNamesAsCamelCase]
    public class Account
    {


        [Key]
        [IsFilterable]
        public string Account_Number { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public double? Balance { get; set; }

        [IsSearchable, IsFilterable, IsSortable]
        public string FirstName { get; set; }
        [IsSearchable, IsFilterable, IsSortable]
        public string LastName { get; set; }

        public int Age { get; set; }
        [IsSearchable, IsFilterable, IsSortable]
        public string Address { get; set; }
        [IsSearchable, IsFilterable, IsSortable]
        public string Email { get; set; }
        [IsSearchable, IsFilterable, IsSortable]
        public string City { get; set; }

        public string State { get; set; }
    }
}
