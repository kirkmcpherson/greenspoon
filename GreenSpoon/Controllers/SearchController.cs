using GreenSpoon.Domain.Search.SearchModels;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;
//using Sitecore.ContentSearch;
//using Sitecore.ContentSearch.Linq;
//using Sitecore.ContentSearch.Linq.Utilities;
//using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc;
using GreenSpoon.Domain.Items;
using GreenSpoon.Domain.Items.GreenSpoon.Recipes;
using GreenSpoon.Domain.Items.GreenSpoon.Search;
using Greenspoon.Models.Search;
using Glass.Mapper.Sc.Web.Mvc;
using GreenSpoon.Models.Search;
using GreenSpoon.Domain.Extensions;

namespace GreenSpoon.Controllers
{
    public class SearchController : GlassController
    {
        // GET: Search
        public ActionResult Search(SearchFilterModel filterModel)
        {
            string findValue = filterModel.Q;

            if (filterModel.Q == null)
            {
                filterModel.Q = String.Empty;
            }

            var context = ContentSearchManager.GetIndex("sitecore_master_index").CreateSearchContext();

            var predicate = PredicateBuilder.False<GreenSpoonSearchResultItem>();
            predicate = predicate.Or(x => x.Content.Contains(findValue));
            predicate = predicate.Or(x => x.RecipeSteps.Contains(findValue));
            predicate = predicate.And(i => i["_templates"].Contains(typeof(IRecipePage).GetTemplateId().Normalize()));

            IQueryable<GreenSpoonSearchResultItem> query_with_facet = context.GetQueryable<GreenSpoonSearchResultItem>().Where(predicate);

            //IQueryable<GreenSpoonSearchResultItem> query_with_facet = context.GetQueryable<GreenSpoonSearchResultItem>().Where(x => x.RecipeSteps.Contains(findValue));

            //var searchResults = context.GetQueryable<GreenSpoonSearchResultItem>().Where(x => x.RecipeSteps.Contains(find_value)).Take(10).GetResults();

            List<string> Facets = new List<string>();
            Facets.Add("recipe_category");

            query_with_facet = Facets.Aggregate(query_with_facet, (current, facetName) => current.FacetOn(c => c[facetName]));

            var searchResults = query_with_facet.GetResults();

            var facetResults = query_with_facet.GetFacets();

            //var facets = context.GetQueryable<GreenSpoonSearchResultItem>().FacetOn(t => t["recipe_category"]);

            //var searchResults = facets.GetResults();

            //var facetResults2 = facets.GetFacets();

            //var facetSearchResults = facetResults.Hits
            //var searchResults = context.GetQueryable<GreenSpoonSearchResultItem>()
            //            .Where(item => item.TemplateName == "Recipes Page")
            //            .Take(10)
            //            .GetResults();

            //IEnumerable<ISearchable> glassSearchResults = searchManager.GetResultsAsGlassItems(searchResults);
            IEnumerable<IBaseItem> glassSearchResults = GetResultsAsGlassItems(searchResults);

            var results = glassSearchResults.ToList();

            foreach (var glassResult in results)
            {
                if (glassResult is IRecipePage)
                {
                    IRecipePage page = glassResult as IRecipePage;
                }
            }

            var model = new SearchViewModel<ISearchPage, SearchFilterModel>()
            {
                PageModel = SitecoreContext.GetCurrentItem<ISearchPage>(false,true),
                GlassSearchResults = glassSearchResults,
                FilterModel = filterModel,
            //    ResultsCount = searchResults.TotalSearchResults,
            //    PaginationThreshold = MassMutualConfig.DocumentsSearchPageSize
            };

            //var results = context.GetQueryable<SearchResultItem>().Where(predicate).GetResults();

            //results.
            //int count = results.Count();
            //Item theItem = results.First().Document.GetItem();

            //SearchResults<RecipePage>
            return View("~/Views/Renderers/Pages//Search/SearchPage.cshtml", model);
        }

        private IEnumerable<IBaseItem> GetResultsAsGlassItems(SearchResults<GreenSpoonSearchResultItem> rawSearchResults)
        {
            var sitecoreService = new SitecoreService("master");

            return
                rawSearchResults.Hits.Select(h =>
                    Sitecore.Context.Database.GetItem(h.Document.ItemId, Sitecore.Context.Language))
                        .Where(i => i != null)
                //.Select(h => h.GlassCast<IBaseItem>(inferType: true));
                    .Select(h => sitecoreService.Cast<IBaseItem>(h, false, true));
        }
    }
}