using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Items
{
    [SitecoreType(TemplateId = "{1930BBEB-7805-471A-A3BE-4858AC7CF696}", AutoMap = true)]
    public interface IBaseItem
    {
        [SitecoreId]
        Guid Id { get; set; }

        Guid TemplateId { get; set; }
        [SitecoreInfo(SitecoreInfoType.BaseTemplateIds)]
        IEnumerable<Guid> BaseTemplateIds { get; set; }

        string Name { get; set; }
        string DisplayName { get; set; }

        string Url { get; set; }
        string Path { get; set; }

        //This is Generic so it can be used on all items
        [SitecoreParent(InferType = true)]
        IBaseItem ParentItem { get; set; }

        Language Language { get; set; }

        [SitecoreLinked(InferType = true, Option = SitecoreLinkedOptions.All)]
        IEnumerable<IBaseItem> Linked { get; set; }

        [SitecoreItem]
        Item SitecoreItem { get; set; }
    }
}
