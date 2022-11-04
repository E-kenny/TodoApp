using System.Data.SqlClient;
using System.Diagnostics;
using TodoRepositories.Interfaces;
using System.Threading.Tasks;

namespace TodoRepositories.Implementations
{
    public class ActivityRepository : IActivityRepository
    {
        public async Task  CreateActivity(string description, string startTime, string duration)
        {
            string queryString = "INSERT INTO activities (description, startTime, duration, Created_at) VALUES(@description, @startTime, @duration, GETDATE()); ";
            using (SqlConnection connection = Db.GetSqlConnection())
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@startTime", startTime);
                command.Parameters.AddWithValue("@duration", duration);
               
               
                command.ExecuteNonQuery();

            }

        }


        public async Task<ActivityItem> ReadActivity(int Id)
        {
            string queryString = " SELECT * from dbo.activities "
            + "WHERE Id = @Id ";
            int paramValue = Id;
            ActivityItem activity = new ActivityItem();
            using (SqlConnection connection = Db.GetSqlConnection())
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", paramValue);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {              
                    activity.Id = (int)reader[0];
                    activity.Description = (string)reader[1];
                    activity.StartTime = (string)reader[2];
                    activity.Duration = (string)reader[3];
                  
                }
                reader.Close();
            }
            return activity;
        }


        public async Task<List<ActivityItem>> ReadAllActivity()
        {
            var allActivity = new List<ActivityItem>();
            string queryString = " SELECT * from dbo.activities ";
            using (SqlConnection connection = Db.GetSqlConnection())
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
                {
                    ActivityItem activity = new ActivityItem();
                    activity.Id = (int)reader[0];
                    activity.Description = (string)reader[1];
                    activity.StartTime = (string)reader[2];
                    activity.Duration = (string)reader[3];
                    allActivity.Add(activity);
                }
                reader.Close();
            }
            return allActivity;
        }



        public async Task<ActivityItem> UpdateActivity(ActivityItem updatedData)
        {
            string queryString = " Update dbo.activities SET description=@description, startTime=@startTime, duration=@duration WHERE Id = @Id ";

            int? paramValue = updatedData.Id;
            ActivityItem activity = new ActivityItem();

            using (SqlConnection connection = Db.GetSqlConnection())
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", paramValue);
                command.Parameters.AddWithValue("@description", updatedData.Description);
                command.Parameters.AddWithValue("@startTime", updatedData.StartTime);
                command.Parameters.AddWithValue("@duration", updatedData.Duration);
            
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    activity.Id = (int)reader[0];
                    activity.Description = (string)reader[1];
                    activity.StartTime = (string)reader[2];
                    activity.Duration = (string)reader[3];
                   
                }
                reader.Close();
            }
            return activity;
        }



        public async Task<ActivityItem> DeleteActivity(int Id)
        {
            string queryString = " DELETE FROM dbo.activities WHERE Id = @Id ";
            int paramValue = Id;
            ActivityItem activity = new ActivityItem();
            using (SqlConnection connection = Db.GetSqlConnection())
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", paramValue);
                command.ExecuteNonQuery();
                connection.Close();
                return activity;
            }
        }


        public async Task<ActivityItem> DeleteOneOrMore(string Id)
        {
            string queryString = " Update dbo.activities SET description WHERE Id = @Id ";
            string paramValue = Id;
            ActivityItem activity = new ActivityItem();
            using (SqlConnection connection = Db.GetSqlConnection())
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
                command.ExecuteNonQuery();
                connection.Close();
            }
            return activity;
        }


        public async Task<ActivityItem> SearchActivity(string word)
        {
            string queryString = " SELECT * from dbo.activities "
            + "WHERE description LIKE % @word";
            string paramValue = word;
            ActivityItem activity = new ActivityItem();
            using (SqlConnection connection = Db.GetSqlConnection())
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", paramValue);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    activity.Id = (int)reader[0];
                    activity.Description = (string)reader[1];
                    activity.StartTime = (string)reader[2];
                    activity.Duration = (string)reader[3];
                }
                reader.Close();
            }
            return activity;
        }


    }
}
