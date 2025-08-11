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

        TestDB2Entities db = new TestDB2Entities();  

        public static Mapper GetMapper()             
        {
            var config = new MapperConfiguration(cfg =>   
            {
                cfg.CreateMap<SupervisorDTO, Supervisor>().ReverseMap();
                cfg.CreateMap<MemberDTO, Member>().ReverseMap();
                cfg.CreateMap<ProjectStatusDTO, ProjectStatu>().ReverseMap();
                cfg.CreateMap<Project, ProjectDetailsDTO>().ReverseMap();
            });

            var mapper = new Mapper(config);     
            return mapper;                       
        }
        public ActionResult Index()
        {
            var list = db.Projects.ToList();                         
            var data = GetMapper().Map<List<ProjectDetailsDTO>>(list); 
            return View(data);                                          
        }

        public ActionResult Details(int id)
        {

            var project = db.Projects.Find(id); 
            if (project == null)
            {
                return HttpNotFound(); 
            }
            var projectDetails = GetMapper().Map<ProjectDetailsDTO>(project); 
            projectDetails.Supervisor = GetMapper().Map<SupervisorDTO>(project.Supervisor); 
            projectDetails.Members = GetMapper().Map<List<MemberDTO>>(project.Members.ToList()); 
            return View(projectDetails); 
        }

    }

}