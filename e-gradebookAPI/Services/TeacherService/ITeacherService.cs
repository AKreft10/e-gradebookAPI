using e_gradebookAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Services.TeacherService
{
    public interface ITeacherService
    {
        Task AddGradeAsync(AddGradeDto dto);
        Task RemoveGradeByIdAsync(int id);
        Task ReplaceGradeAsync(ReplaceGradeDto dto);
        Task<List<StudentDto>> GetStudentsListAsync();
        Task<List<StudentDto>> GetStudentsByGradeYearIdAsync(string gradeYearId);
        Task<List<GradeDto>> GetGradesBySubjectIdAsync(int subjectId);
        Task AddOpinionToStudentAsync(AddOpinionDto dto);
        Task EditOpinionByIdAsync(EditOpinionDto dto);
        Task RemoveOpinionByIdAsync(int id);
    }
}
