using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            ViewBag.Employees = employees;
            return View();
        }

        public IActionResult CreateEdit(int id)
        {
            if(id == 0)
            {
                return View("CreateEditEmployee");
            }
            
            var employee = _context.Employees.Find(id);

            if(employee == null)
            {
                return NotFound();
            }

            return View("CreateEditEmployee", employee);
        }

        [HttpPost]
        public IActionResult CreateEditEmployee(Employee employee)
        {
            if(employee.ID == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                _context.Employees.Update(employee);
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if(employee == null)
            {
                return NotFound();
            }
            
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}