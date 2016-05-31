namespace Greenspoon.Models.Search
{
    using GreenSpoon.Domain.Items;
    using GreenSpoon.Models.Search;
    //using Domain.Items.MassMutual.Common;
    //using Domain.Items.MassMutual.Pages.Search;
    using System.Collections.Generic;
    using System.Linq;

    public class SearchViewModel<TPageModel, TFilterModel> where TFilterModel : SearchFilterModel
    {
        public int PaginationThreshold { get; set; }

        public TFilterModel FilterModel { get; set; }
        public TPageModel PageModel { get; set; }
        //public IEnumerable<ISearchable> GlassSearchResults { get; set; }
        public IEnumerable<IBaseItem> GlassSearchResults { get; set; }
        //public GlossarySearchResult GlossaryResult { get; set; }
        //public IEnumerable<IRelatedSearch> RelatedSearches { get; set; }
        //public ISearchable FeaturedItem { get; set; }

        
        public int ResultsCount { get; set; }

        public bool HasResults
        {
            get
            {
                return GlassSearchResults != null && GlassSearchResults.Any();
            }
        }

        /*
        public bool HasRelatedSearches
        {
            get
            {
                return RelatedSearches != null && RelatedSearches.Any();
            }
        }
        */
        public bool HasPreviousPage
        {
            get
            {
                return FilterModel.Page > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return NumberOfPages > FilterModel.Page;
            }
        }

        public int NumberOfPages
        {
            get
            {
                if (ResultsCount % PaginationThreshold == 0)
                {
                    return ResultsCount / PaginationThreshold;
                }
                return ResultsCount / PaginationThreshold + 1;
            }
        }

        public bool IsPaginated
        {
            get
            {
                return GlassSearchResults != null && GlassSearchResults.Count() > PaginationThreshold;
            }
        }

        public string GetCurrentResultsItemRange()
        {
            var rangeFrom = (PaginationThreshold * FilterModel.Page.Value) - PaginationThreshold;

            var rangeTo = HasNextPage
                            ? rangeFrom + PaginationThreshold
                            : ResultsCount;

            return (rangeFrom + 1) + " - " + rangeTo;
        }
         
         
    }
}