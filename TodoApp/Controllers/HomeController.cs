using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.Models;
using TodoRepositories.Interfaces;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IActivityRepository _activityRepository;

        public HomeController(ILogger<HomeController> logger, IActivityRepository activityRepository)
        {
            _logger = logger;
            _activityRepository = activityRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
           var activity =await _activityRepository.ReadActivity(id);
            return View(activity);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}