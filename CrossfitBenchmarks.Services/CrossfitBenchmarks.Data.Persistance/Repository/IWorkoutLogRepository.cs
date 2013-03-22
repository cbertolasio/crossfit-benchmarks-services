using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossfitBenchmarks.Data.DataTransfer;

namespace CrossfitBenchmarks.Data.Persistance
{
    public interface IWorkoutLogRepository : IRepository<WorkoutLog>
    {
        bool Delete(int id, string identityProvider, string nameIdentifier);
        bool DeleteAll(int id, string identityProvider, string nameIdentifier);
        WorkoutLogEntryDto GetSingleWorkoutLogEntry(LogEntryDto logEntry);

        LogEntryDto Create(LogEntryDto dataToSave);
        IEnumerable<WorkoutLogEntryDto> GetWorkoutLogEntries(int userId, string workoutTypeId);
    }
}

