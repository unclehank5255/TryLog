using System;

namespace TryLog.Models
{
    public enum UserRole
    {
        User = 0,
        Admin = 1
    }

    public enum GoalSortMode
    {
        ReminderTime = 0,
        Name = 1
    }

    public enum ThemeName
    {
        Auto = 0,
        Light = 1,
        Dark = 2
    }

    public enum FrequencyType
    {
        DaysPerWeek = 0,
        SpecificDays = 1
    }

    [Flags]
    public enum WeekdayFlags
    {
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }

    public enum CheckInStatus
    {
        Done = 1,
        Missed = 2,
        Skipped = 3
    }

    public enum AttemptResult
    {
        Useful = 1,
        NotUseful = 2
    }

    public enum EmailChangeStatus
    {
        Pending = 0,
        Completed = 1,
        Cancelled = 2,
        Reverted = 3
    }

    public enum DayState
    {
        Past,
        Today,
        Future
    }
}
