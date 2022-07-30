using Microsoft.AspNetCore.Mvc;
using School.System.Services;
using School.System.ViewModels;
using System.Diagnostics;
using static School.System.ViewModels.StudentViewModel;

namespace School.System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //added for .services dependencies
        private readonly IStudentService studentService;


        public HomeController(ILogger<HomeController> logger,  IStudentService studentService)
        {
            _logger = logger;
            this.studentService = studentService;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //yes ma model state okay cha bane true retun garcga ani yo student srevice ma yesko create ma equivalent model banai dincha & index ma return garcha (bool, string) bool is item 1 and string is item 2
        // false baye view return garcha
        public IActionResult CreateStudent(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = studentService.Create(model);
                if (res.Item1)
                    return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var res = studentService.SoftDelete(id);
            if (res.Item1)
                return RedirectToAction("Index");
            return View("Error has occured.");
        }
    }
}