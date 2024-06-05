using Domain.Entities.Relationships;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Routine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Repetitions { get; set; }
        public TimeSpan BreakTime { get; set; }

        public ICollection<TrainingRoutines> TrainingRoutines { get; set; }
    }
}
