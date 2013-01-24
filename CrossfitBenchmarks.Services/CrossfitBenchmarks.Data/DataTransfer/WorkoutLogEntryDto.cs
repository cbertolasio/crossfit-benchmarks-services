﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossfitBenchmarks.Data.DataTransfer
{
    public class WorkoutLogEntryDto
    {
        public string WorkoutName { get; set; }
        public int WorkoutId { get; set; }
        public LogEntryDto LastEntry { get; set; }
        public LogEntryDto LastPersonalRecord { get; set; }

        public WorkoutLogEntryDto()
        {
            LastEntry = new LogEntryDto();
            LastPersonalRecord = new LogEntryDto();
        }
    }

    public class LogEntryDto
    {
        public long WorkoutLogId { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public string Score { get; set; }
        public bool IsAPersonalRecord { get; set; }

        public  LogEntryDto()
        {
            
        }
    }
}