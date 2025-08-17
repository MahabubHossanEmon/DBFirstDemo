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
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student stu)
    {
        if(ModelState.IsValid)
        {
            try
            {
                context.Students.Add(stu);
                context.SaveChanges();
                TempData["success"] = "Data Insert Successfuly";
            }
            catch(Exception ex)
            {
                TempData["message"] = "insert fail";
            }
            return RedirectToAction("List");
        }
        return View(stu);
    }

    public IActionResult Edit(int? id)
    {
        if (id != null)
        {
           Student stu = context.Students.FirstOrDefault(item => item.Roll == id);
            if (stu != null)
            {
                return View(stu);
            }
            else
            {
                TempData["message"] = "Not found";
                return RedirectToAction("List");
            }

        }
        TempData["message"] = "Please Pass Roll To  Edit";
        return RedirectToAction("List");
    }

    [HttpPost]
    public IActionResult Edit(Student stu)
    {
        if (ModelState.IsValid)
        {
            context.Students.Update(stu);
            context.SaveChanges();
            TempData["success"] = "Data Update Successfuly";
            return RedirectToAction("list");
        }
        return View(stu);
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
                TempData["message"] = "Student Not Found :" + id;
                return RedirectToAction("List");
            }
        }
         TempData["message"] = "Please Pass Roll To Search Information";
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
