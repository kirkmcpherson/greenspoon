using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenSpoon.Models.Search
{
    public class SearchFilterModel
    {
        public SearchFilterModel()
        {
            Page = 1;
        }

        public string Q { get; set; }
        public IEnumerable<Guid> Facets { get; set; }
        public int? Page { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}