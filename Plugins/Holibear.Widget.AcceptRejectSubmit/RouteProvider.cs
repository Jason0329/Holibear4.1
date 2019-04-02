using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holibear.Widget.AcceptRejectSubmit
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Holibear.Widget.AcceptRejectSubmit", "Holibear/Widget/AcceptRejectSubmit",
            new { controller = "WidgetsAcceptRejectButton", action = "OrderStatusUpdate" });

            //ViewEngines.Engines.Insert(0, new CustomViewEngine());
        }
        public int Priority
        {
            get
            {
                return -1;
            }
        }
    }
}
