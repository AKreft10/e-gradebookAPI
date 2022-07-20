using e_gradebookAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Dtos
{
    public class AddGradeDto
    {
        public int GradeValue { get; set; }
        public int GradeWeight { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
