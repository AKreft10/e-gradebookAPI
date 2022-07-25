using e_gradebookAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Dtos
{
    public class AddOpinionDto
    {
        public string Content { get; set; } = string.Empty;
        public int StudentId { get; set; }
    }
}
