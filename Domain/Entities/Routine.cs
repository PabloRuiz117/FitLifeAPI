using Domain.Entities.Relationships;
using System.ComponentModel.DataAnnotations;
using static Common.Enums.Enumerations;

namespace Domain.Entities
{
    public class Routine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public int Repetitions { get; set; }
        public TimeSpan BreakTime { get; set; }
        [Required]
        [MaxLength(100)]
        public string Duration { get; set; }
        [Required]
        public DietType DietType { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public ICollection<TrainingRoutines> TrainingRoutines { get; set; }
    }
}
