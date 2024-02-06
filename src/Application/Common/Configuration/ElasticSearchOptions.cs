using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elastic_search_api.Application.Common.Configuration
{
    public class ElasticSearchOptions
    {
        public const string ElasticSearch = "ElasticSearch";
        public string Url { get; set; }
        public string DocumentIndex { get; set; }
    }
}
