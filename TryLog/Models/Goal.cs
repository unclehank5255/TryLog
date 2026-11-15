using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    public class Goal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Why { get; set; }

        public bool IsPinned { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        public TimeSpan? ReminderTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ArchivedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        public virtual ICollection<GoalSchedule> Schedules { get; set; }
        public virtual ICollection<Attempt> Attempts { get; set; }
        public virtual ICollection<CheckIn> CheckIns { get; set; }
    }
}
