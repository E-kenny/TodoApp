using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoRepositories;
using TodoRepositories.Interfaces;

namespace TodoApp.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }


        // GET: ActivityController
        public async Task<ActionResult> Index()
        {      
            var allActivities = await _activityRepository.ReadAllActivity();
            ViewData["allActivities"] = allActivities;                                
            return View(allActivities);
        }

      

        [HttpPost]
        //GET: ActivityController/Create
        public async Task<ActionResult> Create(string description, string startTime, string duration)
        {
            try
            {
                await _activityRepository.CreateActivity(description, startTime, duration);
                return Redirect("/Activity");
            }
            catch
            {
                return Redirect("/");
            }

        }


        // GET: ActivityController/Edit/5
        public async Task<ActionResult> Edit(int id, string descriptionUpdate, string startTimeUpdate, string durationUpdate, string statusUpdate)
        {
            var activity = new ActivityItem
            {
                Id = id,
                Description = descriptionUpdate,
                StartTime = startTimeUpdate,
                Duration = durationUpdate,
               

            };
           await _activityRepository.UpdateActivity(activity);
            return Redirect("/Activity");
        }

        // POST: ActivityController
        [HttpPost]
        public async Task<ActionResult> Search(string word)
        {
            List<ActivityItem> allActivityList = new List<ActivityItem>();
            var allActivities = await _activityRepository.SearchActivities(word);
            if (allActivities.Id == null)
            {
                return Redirect("/Activity/NotFound");
            }
            else
            {
                allActivityList.Add(allActivities);
                ViewData["allActivities"] = allActivities;
                return View(allActivityList);
            }
        }



        public async Task<ActionResult> Delete(int id)
        {
           await _activityRepository.DeleteActivity(id);
            return Redirect("/Activity");
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
