using DemoAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Windows;

namespace DemoAppMVC.Controllers
{
    public class StaffController : Controller
    {
        /*static int Id = 1;
        static List<Staff> staffList = new List<Staff>();*/
        private DemoAppDBContext context;
        public StaffController(DemoAppDBContext demoAppDBContext)
        {
            context = demoAppDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            List<Staff> staffList = context.Staffs.ToList();
            return View(staffList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string FirstName, string LastName, int Age)
        {
            Staff staff = new Staff()
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age
            };
           
            context.Staffs.Add(staff);
            context.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult ViewStaff(int id)
        {
            Staff staff = context.Staffs.Find(id);
             
            return View(staff);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Staff staff = context.Staffs.Find(id);

            return View(staff);
        }

        [HttpPost]
        public IActionResult EditStaff(int Id, string FirstName, string LastName, int Age)
        {
            Staff? staffToUpdate = context.Staffs.Find(Id);

            if (staffToUpdate == null)
            {
                return RedirectToAction("Error");
            }
            staffToUpdate.FirstName = FirstName;
            staffToUpdate.LastName = LastName;
            staffToUpdate.Age = Age;

            context.Staffs.Update(staffToUpdate);
            context.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Staff? staffToDelete = context.Staffs.Find(Id);

            if(staffToDelete == null)
            {
                return RedirectToAction("Error");
            }
            context.Staffs.Remove(staffToDelete);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Error()
        {
            return View();
        }
    }

    }

