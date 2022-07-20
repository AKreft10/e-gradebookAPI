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
    }
}
