using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC5.Models;

namespace MVC5.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> list = new List<Employee>();
        public EmployeeController()
        {
        }
        [HttpPost]
        public JsonResult UniqueIDValue(Employee emp)
        {
            return Json(!list.Any(x => x.Id == emp.Id));
        }
        public IActionResult Index()
        { 
            return View(list);
            
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if(ModelState.IsValid) {
                list.Add(emp);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        public IActionResult Edit (int ?id)
        {
            if (id == null)
            {
                ViewBag.msg = "Please provide an id";
                return View();
            }
            else
            {
                var employee=list.Where(x=>x.Id == id).FirstOrDefault();
                if(employee==null)
                {
                    ViewBag.msg = "No record found for this id";
                    return View();
                }
                else
                {
                    return View(employee);
                }
            }
            
        }
        [HttpPost]
        public IActionResult Edit(Employee employee,int id)
        {
            var temp=list.Where(x=>x.Id == id);
            if (temp != null)
            {
                foreach(Employee emp in temp)
                {
                    if(emp.Id == employee.Id)
                    {
                        emp.Name = employee.Name;
                        emp.DateOfBirth = employee.DateOfBirth;
                        emp.DateOfJoining = employee.DateOfJoining;
                        emp.Salary = employee.Salary;
                        emp.Department = employee.Department;
                        emp.Password = employee.Password;
                        emp.RetypePassword = employee.RetypePassword;                        
                    }

                }
            }
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if(id==null)
            {
                ViewBag.msg = "Please provide an id";
                return View(); 
            }
            else
            {
                var employee = list.Where(x=>x.Id == id).FirstOrDefault(); 
                if (employee == null)
                {
                    ViewBag.msg = "No record found for this id";
                    return View();
                }
                else
                {
                    return View(employee);
                }
            }
            
        }
        [HttpPost]
        public IActionResult Delete(Employee employee,int id) {
            var temp = list.Where((x)=>x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                list.Remove(temp);
                

            }
            return RedirectToAction("Index");
        }
        public IActionResult Display(int? id)
        {
            if (id == null)
            {
                ViewBag.msg = "Please provide an id";
                return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "No record found for this id";
                    return View();
                }
                else
                {
                    return View(employee);
                }
            }

        }



    }
}
