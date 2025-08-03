using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Application.DTO
{
    public class ProjectDTO
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime CompletionDate { get; set; }
        public int SupervisorID { get; set; }
        public int StatusID { get; set; }


    }
}