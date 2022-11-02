namespace TodoApp.Models
{
    public class ActivityModel
    {
        public ActivityModel()
        {

        }

        public int? Id { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
    }
}
