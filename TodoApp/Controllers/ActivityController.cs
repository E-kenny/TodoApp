using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
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
        public ActionResult Index()
        {
           
            var allActivities = _activityRepository.ReadAllActivity();
            ViewData["allActivities"] = allActivities;
                     
             
            return View(allActivities);
        }

        // GET: ActivityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        // GET: ActivityController/Create
        public ActionResult Create(string description, string startTime, string duration, string status)
        {
            try
            {
                _activityRepository.CreateActivity(description, startTime, duration, status);
                return Redirect("/Activity");
            }
            catch
            {
                return Redirect("/");
            }
        
        }

       

        // GET: ActivityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActivityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ActivityController/Delete/5
        public ActionResult Delete(int id)
        {
            _activityRepository.DeleteActivity(id);
            return Redirect("/Activity");
        }

        // POST: ActivityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
