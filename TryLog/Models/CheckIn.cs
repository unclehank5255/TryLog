using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    public class CheckIn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index("IX_Goal_Date", 1, IsUnique = true)]
        public int GoalId { get; set; }

        [Column(TypeName = "date")]
        [Index("IX_Goal_Date", 2, IsUnique = true)]
        public DateTime Date { get; set; }

        public CheckInStatus? Status { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [StringLength(260)]
        public string PhotoPath { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("GoalId")]
        public virtual Goal Goal { get; set; }
    }
}
