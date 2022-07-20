using e_gradebookAPI.Data;
using e_gradebookAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<GradeDto>> GetGradesBySubjectIdAsync(int subjectId);
        Task<List<GradesByStudentDto>> GetGradesByStudentIdAsync(int studentId);
    }
}
