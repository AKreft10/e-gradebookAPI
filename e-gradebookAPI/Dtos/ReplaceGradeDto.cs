using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Dtos
{
    public class ReplaceGradeDto
    {
        public int Id { get; set; }
        public int GradeValue { get; set; }
        public int GradeWeight { get; set; }
    }
}
