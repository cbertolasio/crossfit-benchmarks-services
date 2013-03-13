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
                if (existingPr == null)
                {
                    dataToSave.IsAPersonalRecord = true;
                }
            }

            WorkoutLog logEntry = new WorkoutLog();
            logEntry.DateOfWod = DateTimeOffset.Parse(dataToSave.DateOfWodAsString);
            logEntry.DateCreated = DateTimeOffset.Now;
            logEntry.IsAPersonalRecord = dataToSave.IsAPersonalRecord;
            logEntry.Score = dataToSave.Score;
            logEntry.UserId = Int32.Parse(dataToSave.UserId);
            logEntry.WorkoutId = dataToSave.WorkoutId;
            logEntry.Note = dataToSave.Note;

            this.dbSet.Add(logEntry);
            if (context.SaveChanges() > 0)
            {
                dataToSave.DateOfWod = logEntry.DateOfWod.Value;
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

        public WorkoutLogEntryDto GetSingleWorkoutLogEntry(LogEntryDto logEntry)
        {
            var lastWorkoutEntryQuery = from logItem in dbSet 
                                        where logItem.UserId == logEntry.UserInfo.UserId && logItem.WorkoutId == logEntry.WorkoutId
                                        group logItem by new { logItem.WorkoutId, logItem.UserId } into grp orderby grp.Key
                                        select new { WorkoutId = grp.Key.WorkoutId, UserId = grp.Key.UserId, 
                                            Info = grp.OrderByDescending(gt => gt.DateOfWod).ThenByDescending(gt => gt.WorkoutLogId).FirstOrDefault() };

            var lastWorkoutPrQuery = from logItem in dbSet 
                                     where logItem.UserId == logEntry.UserInfo.UserId && logItem.IsAPersonalRecord && logItem.WorkoutId == logEntry.WorkoutId
                                     group logItem by new { logItem.WorkoutId, logItem.UserId } into grp orderby grp.Key
                                     select new { WorkoutId = grp.Key.WorkoutId, UserId = grp.Key.UserId, 
                                         Info = grp.OrderByDescending(gt => gt.DateOfWod).ThenByDescending(gt => gt.WorkoutLogId).FirstOrDefault() };


            var historyQuery = from wo in context.Set<Workout>()
                               join wol in dbSet on wo.WorkoutId equals wol.WorkoutId into woGroup
                               where wo.WorkoutId == logEntry.WorkoutId 
                               select new { WorkoutName = wo.Name,WorkoutId = wo.WorkoutId, 
                                   LastEntry = lastWorkoutEntryQuery.Where(it => it.WorkoutId == wo.WorkoutId)
                                    .Select(le => new { WorkoutLogId = le.Info.WorkoutLogId, DateOfWod = le.Info.DateOfWod, Score = le.Info.Score, IsAPersonalRecord = le.Info.IsAPersonalRecord }).FirstOrDefault(), 
                                   LastPrEntry = lastWorkoutPrQuery.Where(it => it.WorkoutId == wo.WorkoutId)                                                                                                                                                                                               
                                    .Select(pr => new { WorkoutLogId = pr.Info.WorkoutLogId, DateOfWod = pr.Info.DateOfWod, Score = pr.Info.Score, IsAPersonalRecord = pr.Info.IsAPersonalRecord }).FirstOrDefault() };
            
            var historyItem = historyQuery.SingleOrDefault();
            var workoutEntry = new WorkoutLogEntryDto() {
                    WorkoutName = historyItem.WorkoutName,
                    WorkoutId = historyItem.WorkoutId
                };

            if (historyItem.LastEntry != null)
            {
                workoutEntry.LastEntry = new LogEntryDto {
                        DateOfWod = historyItem.LastEntry.DateOfWod.Value,
                        IsAPersonalRecord = historyItem.LastEntry.IsAPersonalRecord,
                        Score = historyItem.LastEntry.Score,
                        WorkoutLogId = historyItem.LastEntry.WorkoutLogId
                    };
            }

            if (historyItem.LastPrEntry != null)
            {
                workoutEntry.LastPersonalRecord = new LogEntryDto {
                        DateOfWod = historyItem.LastPrEntry.DateOfWod.Value,
                        IsAPersonalRecord = historyItem.LastPrEntry.IsAPersonalRecord,
                        Score = historyItem.LastPrEntry.Score,
                        WorkoutLogId = historyItem.LastPrEntry.WorkoutLogId
                    };
            }

            return workoutEntry;
        }

        public IEnumerable<DataTransfer.WorkoutLogEntryDto> GetWorkoutLogEntries(int userId, string workoutTypeId)
        {
            var lastEntryQuery = from logItem in dbSet
                                 where logItem.UserId == userId
                                 group logItem by new { logItem.WorkoutId, logItem.UserId } into grp orderby grp.Key
                                 select new { WorkoutId = grp.Key.WorkoutId, UserId = grp.Key.UserId, Info = grp.OrderByDescending(gt => gt.DateOfWod).ThenByDescending(gt => gt.WorkoutLogId).FirstOrDefault() };

            var lastPrQuery = from logItem in dbSet
                              where logItem.UserId == userId && logItem.IsAPersonalRecord
                              group logItem by new { logItem.WorkoutId, logItem.UserId } into grp orderby grp.Key
                              select new { WorkoutId = grp.Key.WorkoutId, UserId = grp.Key.UserId, Info = grp.OrderByDescending(gt => gt.DateOfWod).ThenByDescending(gt => gt.WorkoutLogId).FirstOrDefault() };


            var historyQuery = from wo in context.Set<Workout>()
                               join wol in dbSet on wo.WorkoutId equals wol.WorkoutId into woGroup
                               where wo.WorkoutTypeId == workoutTypeId
                               select new { WorkoutName = wo.Name, WorkoutId = wo.WorkoutId, 
                                   LastEntry = lastEntryQuery.Where(it => it.WorkoutId == wo.WorkoutId).Select(le => new { WorkoutLogId = le.Info.WorkoutLogId, DateOfWod = le.Info.DateOfWod, Score = le.Info.Score, IsAPersonalRecord = le.Info.IsAPersonalRecord }).FirstOrDefault(), 
                                   LastPrEntry = lastPrQuery.Where(it => it.WorkoutId == wo.WorkoutId).Select(pr => new { WorkoutLogId = pr.Info.WorkoutLogId, DateOfWod = pr.Info.DateOfWod, Score = pr.Info.Score, IsAPersonalRecord = pr.Info.IsAPersonalRecord }).FirstOrDefault() };


            var result = new List<WorkoutLogEntryDto>();
            foreach (var item in historyQuery.ToList())
            {
                var workoutEntry = new WorkoutLogEntryDto() { WorkoutName = item.WorkoutName,
                    WorkoutId = item.WorkoutId
                };

                if (item.LastEntry != null)
                {
                    workoutEntry.LastEntry = new LogEntryDto { DateOfWod = item.LastEntry.DateOfWod.Value,
                        IsAPersonalRecord = item.LastEntry.IsAPersonalRecord,
                        Score = item.LastEntry.Score,
                        WorkoutLogId = item.LastEntry.WorkoutLogId };
                }

                if (item.LastPrEntry != null)
                {
                    workoutEntry.LastPersonalRecord = new LogEntryDto { DateOfWod = item.LastPrEntry.DateOfWod.Value,
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

