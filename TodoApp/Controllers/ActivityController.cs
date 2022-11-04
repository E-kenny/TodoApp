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
           _activityRepository.UpdateActivity(activity);
            return Redirect("/Activity");
        }


        public async Task<ActionResult> Delete(int id)
        {
            _activityRepository.DeleteActivity(id);
            return Redirect("/Activity");
        }
    }
}
