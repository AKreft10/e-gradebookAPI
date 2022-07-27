using e_gradebookAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Services.AccountService
{
    public interface IAccountService
    {
        Task RegisterNewStudent(RegisterStudentDto dto);
        Task RegisterNewTeacher(RegisterTeacherDto dto);
        string GenerateJwt(LoginDto dto);
    }
}
