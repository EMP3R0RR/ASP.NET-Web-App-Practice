using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.EF;
using Test_Application.DTO;
using AutoMapper;

namespace Test_Application.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        TestDB2Entities db = new TestDB2Entities();  // Instantiates the database context to access EF data.

        public static Mapper GetMapper()             // Static method to configure and return an AutoMapper instance.
        {
            var config = new MapperConfiguration(cfg =>   // Defines the mapping configuration.
            {
                cfg.CreateMap<DepartmentDTO, Department>().ReverseMap();  // Maps DepartmentDTO <--> Department.
                cfg.CreateMap<Department, StudentDepartmentDTO>().ReverseMap(); // Maps Department <--> StudentDepartmentDTO.
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();              // Maps Student <--> StudentDTO.
            });

            var mapper = new Mapper(config);     // Creates a mapper instance using the above config.
            return mapper;                       // Returns the mapper for use in other methods.
        }

        public ActionResult Index()              // Action to handle GET requests for the Department index page.
        {
            var list = db.Departments.ToList();                         // Retrieves all departments from the database.
            var data = GetMapper().Map<List<DepartmentDTO>>(list);     // Maps the list of Department entities to DTOs.
            return View(data);                                          // Passes the mapped data to the view.
        }

        [HttpGet]
        public ActionResult Create()             // Action to handle GET requests for creating a department.
        {
            return View();                       // Returns an empty form for creating a new department.
        }

        [HttpPost]
        public ActionResult Create(DepartmentDTO d)     // Action to handle POST request after form submission.
        {
            var data = GetMapper().Map<Department>(d);  // Maps the submitted DepartmentDTO to a Department entity.
            db.Departments.Add(data);                   // Adds the new department to the EF context.
            db.SaveChanges();                           // Commits the new department to the database.
            return RedirectToAction("Index");           // Redirects user back to the department list.
        }

        [HttpGet]
        public ActionResult Edit(int id)                // Action to handle GET request for editing a department.
        {
            var data = db.Departments.Find(id);         // Finds the department by ID in the database.
            return View(data);                          // Passes the existing department to the view for editing.
        }

        [HttpPost]
        public ActionResult Edit(Department d)          // Action to handle POST request after editing a department.
        {
            var exobj = db.Departments.Find(d.DepartmentID);  // Finds the existing department using the provided ID.
            exobj.Name = d.Name;                              // Updates the department's name with new value.
            db.SaveChanges();                                 // Saves the changes to the database.
            return RedirectToAction("Index");                 // Redirects to the department index page.
        }

        public ActionResult Details(int id)             // Action to display details of a specific department.
        {
            var obj = (from d in db.Departments.Include("Students")  // Retrieves department with related students.
                       where d.DepartmentID == id                    // Filters by the specified department ID.
                       select d).SingleOrDefault();                  // Selects the matching department or null.
            var data = GetMapper().Map<StudentDepartmentDTO>(obj);  // Maps the department and students to a DTO.
            return View(data);                                      // Passes the data to the view for display.
        }
    }
}