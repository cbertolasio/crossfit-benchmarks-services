using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using CrossfitBenchmarks.Data;
using CrossfitBenchmarks.Data.Persistance;
using CrossfitBenchmarks.Services.Utility;
using System.Web.Http.OData.Query;

namespace CrossfitBenchmarks.Services.Controllers.OData
{
    [Authorize]
    public class WorkoutLogsController : EntitySetController<WorkoutLogSummary, int>
    {
        private readonly DbContext context;
        private DbSet<WorkoutLog> workoutLogs;

        [Queryable(AllowedQueryOptions = AllowedQueryOptions.Top | AllowedQueryOptions.Skip | 
            AllowedQueryOptions.Filter | AllowedQueryOptions.InlineCount | AllowedQueryOptions.OrderBy, MaxTop=25 )]
        [NoCache]
        public override IQueryable<WorkoutLogSummary> Get()
        {
           return workoutLogs.Select(it => new WorkoutLogSummary { Notes = it.Note,
                DateOfWod = it.DateOfWod,
                DateCreated = it.DateCreated,
                UserNameIdentifier = it.User.IpNameIdentifier,
                UserId = it.UserId,
                WorkoutLogId = it.WorkoutLogId,
                WorkoutName = it.Workout.Name,
                WorkoutType = it.Workout.WorkoutType.Name,
                WorkoutTypeId = it.Workout.WorkoutTypeId,
                WorkoutId = it.WorkoutId,
                Score = it.Score,
                IsAPersonalRecord = it.IsAPersonalRecord
            });
        }

        protected override WorkoutLogSummary GetEntityByKey(int key)
        {
            return workoutLogs.Where(it => it.WorkoutLogId == key).Select(it => new WorkoutLogSummary {
                Notes = it.Note,
                DateOfWod = it.DateOfWod,
                DateCreated = it.DateCreated,
                UserNameIdentifier = it.User.IpNameIdentifier,
                UserId = it.UserId,
                WorkoutLogId = it.WorkoutLogId,
                WorkoutName = it.Workout.Name,
                WorkoutType = it.Workout.WorkoutType.Name,
                WorkoutTypeId = it.Workout.WorkoutTypeId,
                Score = it.Score,
                IsAPersonalRecord = it.IsAPersonalRecord
            }).FirstOrDefault();
        }

        public WorkoutLogsController(DbContext context)
        {
            this.context = context;
            workoutLogs = this.context.Set<WorkoutLog>();
        }
    }
}