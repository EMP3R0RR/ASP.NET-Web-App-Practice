using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Application.DTO
{
    public class StudentDepartmentDTO : DepartmentDTO
    {
        public List<StudentDTO> Students { get; set; }
        public StudentDepartmentDTO()
        {
            Students = new List<StudentDTO>();
        }
    }
}