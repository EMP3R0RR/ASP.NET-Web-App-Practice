using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Application.DTO
{
    public class ProjectDetailsDTO : ProjectDTO
    {
        public List<SupervisorDTO> Supervisor { get; set; }
        public List<MemberDTO> Members { get; set; }

        public List<ProjectStatusDTO> Status { get; set; }
        public ProjectDetailsDTO()
        {
            Supervisor = new List<SupervisorDTO>();
            Members = new List<MemberDTO>();
            Status = new List<ProjectStatusDTO>();
        }

        

        

    }
}