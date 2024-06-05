namespace Domain.Entities.Relationships
{
    public class TrainingRoutines
    {
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int RoutineId { get; set; }
        public Routine Routine { get; set; }
    }
}
