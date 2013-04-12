using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstAsp.NetMVCApp.Controllers
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class FirstController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            HttpResponseBase resp = requestContext.HttpContext.Response;
            resp.StatusCode = 200;
            resp.ContentType = "text/plain";
            resp.Write("SLB na meia final da UEFA League");

        }
    }
}