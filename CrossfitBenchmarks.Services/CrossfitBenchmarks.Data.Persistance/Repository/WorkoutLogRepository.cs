using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossfitBenchmarks.Data.DataTransfer;

namespace CrossfitBenchmarks.Data.Persistance
{
    public class WorkoutLogRepository : RepositoryBase<WorkoutLog>, IWorkoutLogRepository
    {
        public LogEntryDto Create(LogEntryDto dataToSave)
        {
            if (dataToSave.IsAPersonalRecord)
            {
                // remove existing PRs
                var userId = Int32.Parse(dataToSave.UserId);
                var existingPr = dbSet.Where(it => it.IsAPersonalRecord == true && it.UserId == userId && it.WorkoutId == dataToSave.WorkoutId).SingleOrDefault();
                if (existingPr != null)
                {
                    existingPr.IsAPersonalRecord = false;
                }
            }
            else
            {
                // if user doesnt check the PR flag and they have no PR, make the first entry a PR
                var userId = Int32.Parse(dataToSave.UserId);
                var existingPr = dbSet.Where(it => it.IsAPersonalRecord == true && it.UserId == userId && it.WorkoutId == dataToSave.WorkoutId).SingleOrDefault();
                if (existingPr == null) {
                    dataToSave.IsAPersonalRecord = true;
                }
            }
                

            WorkoutLog logEntry = new WorkoutLog();
            logEntry.DateCreated = DateTimeOffset.Parse(dataToSave.DateCreatedAsString);
            logEntry.IsAPersonalRecord = dataToSave.IsAPersonalRecord;
            logEntry.Score = dataToSave.Score;
            logEntry.UserId = Int32.Parse(dataToSave.UserId);
            logEntry.WorkoutId = dataToSave.WorkoutId;
            logEntry.Note = dataToSave.Note;

            this.dbSet.Add(logEntry);
            if (context.SaveChanges() > 0)
            {
                dataToSave.DateCreated = logEntry.DateCreated.Value;
                dataToSave.WorkoutLogId = logEntry.WorkoutLogId;
                return dataToSave;
            }
            else
            {
                return null;
            }
        }

        public WorkoutLogRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<DataTransfer.WorkoutLogEntryDto> GetWorkoutLogEntries(int userId, string workoutTypeId)
        {
            var lastEntryQuery = from logItem in dbSet
                                                      where logItem.UserId == userId
                                                      group logItem by new { logItem.WorkoutId, logItem.UserId }
                                  into grp
                                                      orderby grp.Key
                                                      select new { WorkoutId = grp.Key.WorkoutId, UserId = grp.Key.UserId, Info = grp.OrderByDescending(gt => gt.DateCreated).FirstOrDefault() };

            var lastPrQuery = from logItem in dbSet
                                                where logItem.UserId == userId && logItem.IsAPersonalRecord
                                                group logItem by new { logItem.WorkoutId, logItem.UserId }
                               into grp
                                                orderby grp.Key
                                                select new { WorkoutId = grp.Key.WorkoutId, UserId = grp.Key.UserId, Info = grp.OrderByDescending(gt => gt.DateCreated).FirstOrDefault() };


            var historyQuery = from wo in context.Set<Workout>()
                                                  join wol in dbSet on wo.WorkoutId equals wol.WorkoutId into woGroup
                                                  where wo.WorkoutTypeId == workoutTypeId
                                                  select new {
                                                      WorkoutName = wo.Name,
                                                      WorkoutId = wo.WorkoutId,
                                                      LastEntry = lastEntryQuery.Where(it => it.WorkoutId == wo.WorkoutId)
                                                          .Select(le => new { WorkoutLogId = le.Info.WorkoutLogId, DateCreated = le.Info.DateCreated, Score = le.Info.Score, IsAPersonalRecord = le.Info.IsAPersonalRecord }).FirstOrDefault(),
                                                      LastPrEntry = lastPrQuery.Where(it => it.WorkoutId == wo.WorkoutId)
                                                          .Select(pr => new { WorkoutLogId = pr.Info.WorkoutLogId, DateCreated = pr.Info.DateCreated, Score = pr.Info.Score, IsAPersonalRecord = pr.Info.IsAPersonalRecord }).FirstOrDefault()
                                                  };


            var result = new List<WorkoutLogEntryDto>();
            foreach (var item in historyQuery.ToList())
            {
                var workoutEntry = new WorkoutLogEntryDto() { WorkoutName = item.WorkoutName,
                    WorkoutId = item.WorkoutId
                };

                if (item.LastEntry != null)
                {
                    workoutEntry.LastEntry = new LogEntryDto { DateCreated = item.LastEntry.DateCreated.Value,
                        IsAPersonalRecord = item.LastEntry.IsAPersonalRecord,
                        Score = item.LastEntry.Score,
                        WorkoutLogId = item.LastEntry.WorkoutLogId };
                }

                if (item.LastPrEntry != null)
                {
                    workoutEntry.LastPersonalRecord = new LogEntryDto { DateCreated = item.LastPrEntry.DateCreated.Value,
                        IsAPersonalRecord = item.LastPrEntry.IsAPersonalRecord,
                        Score = item.LastPrEntry.Score,
                        WorkoutLogId = item.LastPrEntry.WorkoutLogId };
                }

                result.Add(workoutEntry);
            }

            return result;
        }
    }
}

