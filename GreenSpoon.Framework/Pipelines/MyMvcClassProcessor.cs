using Sitecore.Mvc.Pipelines.Request.RequestBegin;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GreenSpoon.Framework.Pipelines
{
    public class MyMvcClassProcessor : RequestBeginProcessor
    //public class MyMvcClassProcessor : HttpRequestProcessor
    {
        public override void Process(RequestBeginArgs args)
        {
            if (HttpContext.Current != null)
            {

            }
        }
    }
}
