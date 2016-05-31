using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Items.GreenSpoon.Recipes
{
    [SitecoreType(TemplateId = "{3F3D2A51-9522-4866-AD62-4C7E952139F4}", AutoMap = true)]
    public interface IRecipePage : IBaseItem
    {
        [SitecoreField(FieldName = "Title")]
        string Title { get; set; }

        [SitecoreField(FieldName = "Description")]
        string Description { get; set; }

        [SitecoreField(FieldName = "Author")]
        string Author { get; set; }

        [SitecoreField(FieldName = "Prep Time")]
        string PrepTime { get; set; }

        [SitecoreField(FieldName = "Main Image")]
        Image MainImage { get; set; }

        [SitecoreChildren(InferType = true)]
        IEnumerable<IRecipeStep> Steps { get; set; }
    }
}
