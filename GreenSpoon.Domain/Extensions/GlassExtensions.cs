using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Extensions
{
    public static class GlassExtensions
    {
        public static Guid GetTemplateId(this Type type)
        {
            var attribute = (SitecoreTypeAttribute)Attribute.GetCustomAttribute(type, typeof(SitecoreTypeAttribute));

            if (attribute == null)
            {
                return default(Guid);
            }

            return attribute.TemplateId.AsNGuid().GetValueOrDefault();
        }

    }
}
