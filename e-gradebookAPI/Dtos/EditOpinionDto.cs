using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Dtos
{
    public class EditOpinionDto
    {
        public int OpinionId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
