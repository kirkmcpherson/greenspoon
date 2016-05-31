using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Items.GreenSpoon.Recipes
{
    [SitecoreType(TemplateId = "{0C86FAFC-3E32-4C76-B8DA-CDAB0172D046}", AutoMap = true)]
    public interface IRecipeStep : IBaseItem
    {
        [SitecoreField(FieldName = "Description")]
        string Description { get; set; }

        [SitecoreField(FieldName = "Image")]
        string Image { get; set; }
    
    }
}
