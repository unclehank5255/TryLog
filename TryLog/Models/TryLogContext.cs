using System.Data.Entity;

namespace TryLog.Models
{
    public class TryLogContext : DbContext
    {
        public TryLogContext() : base("name=TryLogContext")
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalSchedule> GoalSchedules { get; set; }
        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<DailyMood> DailyMoods { get; set; }
    }
}
