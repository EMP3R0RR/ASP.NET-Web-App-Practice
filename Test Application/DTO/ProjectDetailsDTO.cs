using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Application.DTO
{
    public class ProjectDetailsDTO : ProjectDTO
    {
        public SupervisorDTO Supervisor { get; set; }
        public List<MemberDTO> Members { get; set; }

        public ProjectStatusDTO Status { get; set; }
        public ProjectDetailsDTO()
        {
            
            Members = new List<MemberDTO>();
            
        }

        

        

    }
}