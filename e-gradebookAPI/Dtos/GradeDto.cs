using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Dtos
{
    public class GradeDto
    {
        public int GradeValue { get; set; }
        public int GradeWeight { get; set; }
        public StudentDto Student { get; set; }
        public SubjectDto Subject { get; set; }
    }
}
