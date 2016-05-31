using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Extensions
{
    public static class GuidExtensions
    {
        public static ID AsID(this Guid guid)
        {
            return new ID(guid);
        }

        public static string Normalize(this Guid guid)
        {
            return IdHelper.NormalizeGuid(guid.AsID());
        }

    }
}
