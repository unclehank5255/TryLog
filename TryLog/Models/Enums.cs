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
        Custom = 1
    }

    public enum ThemeName
    {
        Milk = 0,
        Cool = 1
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
}
