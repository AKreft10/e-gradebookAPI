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

        Task<List<GradesByStudentDto>> GetGradesByStudentIdAsync(int studentId);
        Task<List<OpinionDto>> GetOpinionsByStudentIdAsync(int studentId);
    }
}
