using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using CrossfitBenchmarks.Data;
using CrossfitBenchmarks.Data.Persistance;

namespace CrossfitBenchmarks.Services.Controllers.OData
{
    public class WorkoutLogSummary
    {
        public Nullable<DateTimeOffset> DateCreated { get; set; }
        public Nullable<DateTimeOffset> DateOfWod { get; set; }
        public bool IsAPersonalRecord { get; set; }
        public string Score { get; set; }
        public int UserId { get; set; }
        public string UserNameIdentifier { get; set; }
        [Key]
        public long WorkoutLogId { get; set; }
        public string WorkoutName { get; set; }
        public string Notes { get; set; }
        public string WorkoutType { get; set; }

        public string WorkoutTypeId { get; set; }
        public  WorkoutLogSummary()
        {
        }
    }
}

