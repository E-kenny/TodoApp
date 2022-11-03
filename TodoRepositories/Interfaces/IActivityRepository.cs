﻿using System.Data.SqlClient;


namespace TodoRepositories.Interfaces
{
    public interface IActivityRepository
    {
        public void CreateActivity(string description, string startTime,string duration);
        public ActivityItem ReadActivity(int Id);
        public List<ActivityItem> ReadAllActivity();
        public ActivityItem UpdateActivity(ActivityItem activityItem);
        public ActivityItem DeleteActivity(int Id);
        public ActivityItem DeleteOneOrMore(string Id);
        public ActivityItem SearchActivity(string word);
    }
}
