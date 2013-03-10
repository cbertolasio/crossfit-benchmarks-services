using CrossfitBenchmarks.Data.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using CrossfitBenchmarks.Data;
using CrossfitBenchmarks.Services.Controllers.OData;

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

            ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
            //var workoutLogs = modelBuilder.EntitySet<WorkoutLog>("WorkoutLogs");
            //modelBuilder.EntitySet<User>("Users");
            //modelBuilder.EntitySet<WorkoutType>("WorkoutTypes");
            //modelBuilder.EntitySet<Workout>("Workouts");
            modelBuilder.EntitySet<WorkoutLogSummary>("WorkoutLogs");

            Microsoft.Data.Edm.IEdmModel model = modelBuilder.GetEdmModel();
            config.Routes.MapODataRoute("ODataRoute", "odata", model);
        }
    }
}
