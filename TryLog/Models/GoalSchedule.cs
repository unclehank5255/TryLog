using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    public class GoalSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index("IX_Goal_EffectiveDate", 1, IsUnique = true)]
        public int GoalId { get; set; }

        [Column(TypeName = "date")]
        [Index("IX_Goal_EffectiveDate", 2, IsUnique = true)]
        public DateTime EffectiveDate { get; set; }

        public FrequencyType FrequencyType { get; set; }

        public int? DaysPerWeek { get; set; }

        public WeekdayFlags Weekdays { get; set; }

        [ForeignKey("GoalId")]
        public virtual Goal Goal { get; set; }
    }
}
