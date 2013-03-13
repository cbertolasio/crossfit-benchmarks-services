using CrossfitBenchmarks.Data.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using CrossfitBenchmarks.Data;
using CrossfitBenchmarks.Services.Controllers.OData;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Converters;

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

            JsonMediaTypeFormatter jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings() {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateParseHandling = DateParseHandling.DateTimeOffset
            };

            jSettings.Converters.Add(new MyDateTimeConvertor());
            jsonFormatter.SerializerSettings = jSettings;

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

    public class MyDateTimeConvertor : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTimeOffset.Parse(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTimeOffset)value).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'sszzz"));
        }
    }
}
