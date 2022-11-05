using System.Data.SqlClient;


namespace TodoRepositories.Interfaces
{
    public interface IActivityRepository
    {
        public Task CreateActivity(string description, DateTime startTime,string duration);
        public Task<ActivityItem> ReadActivity(int Id);
        public Task<List<ActivityItem>> ReadAllActivity();
        public Task<ActivityItem> UpdateActivity(ActivityItem activityItem);
        public Task<ActivityItem> DeleteActivity(int Id);
        public Task<ActivityItem> DeleteOneOrMore(string Id);
        public Task<ActivityItem> SearchActivities(string word);
    }
}
