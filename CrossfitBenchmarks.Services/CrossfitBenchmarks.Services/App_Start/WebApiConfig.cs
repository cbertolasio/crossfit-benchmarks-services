using CrossfitBenchmarks.Data.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace CrossfitBenchmarks.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
            //modelBuilder.EntitySet<LogEntryDto>("LogEntry");

            //Microsoft.Data.Edm.IEdmModel model = modelBuilder.GetEdmModel();
            //config.Routes.MapODataRoute("ODataRoute", "odata", model);
        }
    }
}
