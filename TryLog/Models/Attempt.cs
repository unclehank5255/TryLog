using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    public class Attempt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index("IX_Goal_AttemptNo", 1, IsUnique = true)]
        public int GoalId { get; set; }

        [Index("IX_Goal_AttemptNo", 2, IsUnique = true)]
        public int AttemptNo { get; set; }

        [Required]
        [StringLength(30)]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [StringLength(200)]
        public string Plus { get; set; }

        [StringLength(200)]
        public string Minus { get; set; }

        public AttemptResult? Result { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EvaluatedAt { get; set; }

        [ForeignKey("GoalId")]
        public virtual Goal Goal { get; set; }
    }
}
