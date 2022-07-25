using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Data
{
    public class Opinion
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Teacher CreatedBy { get; set; } = new Teacher();
        public DateTime CreationDate { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = new Student();
    }
}
