using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Items.GreenSpoon.Search
{
    [SitecoreType(TemplateId = "{6B318E6D-CF46-41BA-93E7-141E51FD8D04}", AutoMap = true)]
    public interface ISearchPage : IBaseItem
    {
        [SitecoreField(FieldName = "Title")]
        string Title { get; set; }

        [SitecoreField(FieldName = "Description")]
        string Description { get; set; }

        [SitecoreField(FieldName = "Results")]
        string Results { get; set; }

    }
}
