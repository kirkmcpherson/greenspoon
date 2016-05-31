using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Items.GreenSpoon.Recipes
{
    [SitecoreType(TemplateId = "{D6097BDA-F49A-4359-92AD-CC0850F29BB3}", AutoMap = true)]
    public interface IRecipesLandingPage : IBaseItem
    {
        [SitecoreField(FieldName = "Title")]
        string Title { get; set; }

        [SitecoreField(FieldName = "Description")]
        string Description { get; set; }
    }
}
