using e_gradebookAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Dtos
{
    public class OpinionDto
    {
        public string Content { get; set; } = string.Empty;
        public string TeacherFirstName { get; set; } = string.Empty;
        public string TeacherLastName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}
