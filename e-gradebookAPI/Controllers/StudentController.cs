using e_gradebookAPI.Data;
using e_gradebookAPI.Dtos;
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

        public StudentController(IStudentService gradeSerive)
        {
            _gradeService = gradeSerive;
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
    }
}
