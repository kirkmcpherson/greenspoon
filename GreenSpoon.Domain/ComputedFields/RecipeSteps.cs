using GreenSpoon.Domain.Items.GreenSpoon.Recipes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc;

namespace GreenSpoon.Domain.ComputedFields
{
    class RecipeSteps : IComputedIndexField
    {

        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            //Assert.ArgumentNotNull(indexable, "indexable");
           // string url = null;
            try
            {
                var sitecoreService = new SitecoreService("master");

                Item item = indexable as SitecoreIndexableItem;

                StringBuilder indexSteps = new StringBuilder();

                //Only parsing page items
                if (item == null) return null;
                if (item.TemplateName != "Recipes Page") return null;

                //var recipe = item.GlassCast<RecipePage>();
                var recipe = sitecoreService.CreateType<IRecipePage>(item);

                if(recipe != null)
                {
                    foreach(var step in recipe.Steps)
                    {
                        indexSteps.Append(step.Description);
                    }

                    return indexSteps.ToString();
                }
            }
            catch (Exception exc)
            {
                Log.Error(string.Format("An error occurred when indexing {0}: {1}", indexable.Id, exc.Message), exc, this);
            }
            return null;
        }


       
    }
}
