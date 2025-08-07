using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.EF;
using Test_Application.DTO;

namespace Test_Application.Controllers
{
    public class ProjectDetailsController : Controller
    {
        // GET: ProjectDetails

        TestDB2Entities db = new TestDB2Entities();  // Instantiates the database context to access EF data.

        public static Mapper GetMapper()             // Static method to configure and return an AutoMapper instance.
        {
            var config = new MapperConfiguration(cfg =>   // Defines the mapping configuration.
            {
                cfg.CreateMap<SupervisorDTO, Supervisor>().ReverseMap();
                cfg.CreateMap<MemberDTO, Member>().ReverseMap();
                cfg.CreateMap<ProjectStatusDTO, ProjectStatu>().ReverseMap();
                cfg.CreateMap<Project, ProjectDetailsDTO>().ReverseMap();
            });

            var mapper = new Mapper(config);     // Creates a mapper instance using the above config.
            return mapper;                       // Returns the mapper for use in other methods.
        }
        public ActionResult Index()
        {
            var list = db.Projects.ToList();                         // Retrieves all projects from the database.
            var data = GetMapper().Map<List<ProjectDetailsDTO>>(list); // Maps the list of Project entities to DTOs.
            return View(data);                                          // Passes the mapped data to the view.  
        }

        public ActionResult Details(int id)
        {

            var project = db.Projects.Find(id); // Finds the project by ID in the database.
            if (project == null)
            {
                return HttpNotFound(); // Returns a 404 error if the project is not found.
            }
            var projectDetails = GetMapper().Map<ProjectDetailsDTO>(project); // Maps the Project entity to ProjectDetailsDTO.
            projectDetails.Supervisor = GetMapper().Map<SupervisorDTO>(project.Supervisor); // Maps Supervisor entity to SupervisorDTO.
            projectDetails.Members = GetMapper().Map<List<MemberDTO>>(project.Members.ToList()); // Maps Members collection to List<MemberDTO>.
            return View(projectDetails); // Passes the project details DTO to the view.
        }

    }

}