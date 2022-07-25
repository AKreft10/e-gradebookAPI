using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string GradeYear { get; set; } = string.Empty;
        public List<Grade> Grades { get; set; }
        public List<Opinion> Opinions { get; set; }

    }
}
