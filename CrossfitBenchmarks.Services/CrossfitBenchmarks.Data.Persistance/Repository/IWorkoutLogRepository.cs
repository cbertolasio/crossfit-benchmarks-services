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
        LogEntryDto Create(LogEntryDto dataToSave);
        IEnumerable<WorkoutLogEntryDto> GetBenchmarkDataForUser(int userId);
    }
}

