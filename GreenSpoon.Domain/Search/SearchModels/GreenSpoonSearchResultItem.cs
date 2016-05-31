using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Search.SearchModels
{
    public class GreenSpoonSearchResultItem : SearchResultItem
    {
        //public virtual string Url { get; set; }
        [IndexField("recipe_steps")]
        public string RecipeSteps { get; set; }
    }
}
