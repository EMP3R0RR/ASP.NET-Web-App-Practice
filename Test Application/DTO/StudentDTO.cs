using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Application.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cgpa { get; set; }
        public System.DateTime Dob { get; set; }
        public int DepartmentID { get; set; }
    }
    
}