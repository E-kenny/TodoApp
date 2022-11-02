using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoRepositories
{
    public class ActivityItem
    {

        public ActivityItem()
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
