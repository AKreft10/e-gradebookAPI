using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Data
{
    public class Grade
    {
        public int Id { get; set; }
        public int GradeValue { get; set; }
        public int GradeWeight { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
