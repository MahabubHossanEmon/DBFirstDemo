using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DBFirstDemo.Models;

namespace DBFirstDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TestDbContext context;

    public HomeController(ILogger<HomeController> logger, TestDbContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List()
    {
        List<Student> students = context.Students.ToList();
        return View(students);

    }

    public IActionResult Details(int? id)
    {
        if (id!=null)
        {
            Student st = context.Students.FirstOrDefault(item => item.Roll == id); 
            if(st != null)
            {
                return View(st);
            }
            else
            {
                TempData["message"] = "Not Found :" + id;
                return RedirectToAction("List");
            }
        }
        return RedirectToAction("List");
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
}
