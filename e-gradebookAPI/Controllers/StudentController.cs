using e_gradebookAPI.Data;
using e_gradebookAPI.Dtos;
using e_gradebookAPI.Services.AccountService;
using e_gradebookAPI.Services.StudentService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _gradeService;
        private readonly IAccountService _accountService;

        public StudentController(IStudentService gradeSerive, IAccountService accountService)
        {
            _gradeService = gradeSerive;
            _accountService = accountService;
        }

        [HttpGet("grades/{studentId}")]
        public async Task<ActionResult<List<GradesByStudentDto>>> GetGradesByStudentId(int studentId)
        {
            var grades = await _gradeService.GetGradesByStudentIdAsync(studentId);
            return Ok(grades);
        }

        [HttpGet("opinions/{studentId}")]
        public async Task<ActionResult<List<OpinionDto>>> GetOpinionsByStudentId(int studentId)
        {
            var opinions = await _gradeService.GetOpinionsByStudentIdAsync(studentId);
            return Ok(opinions);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
        
    }
}
