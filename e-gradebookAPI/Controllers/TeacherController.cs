using e_gradebookAPI.Dtos;
using e_gradebookAPI.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Controllers
{
    [ApiController]
    [Route("teacher")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("grades/add")]
        public async Task<ActionResult> AddGrade([FromBody] AddGradeDto dto)
        {
            await _teacherService.AddGradeAsync(dto);
            return Ok();
        }

        [HttpDelete("grades/remove")]
        public async Task<ActionResult> RemoveGrade([FromBody]int id)
        {
            await _teacherService.RemoveGradeByIdAsync(id);
            return NoContent();
        }

        [HttpPut("grades/replace")]
        public async Task<ActionResult> ReplaceGrade([FromBody] ReplaceGradeDto dto)
        {
            await _teacherService.ReplaceGradeAsync(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetStudentsList()
        {
            var students = await _teacherService.GetStudentsListAsync();
            return Ok(students);
        }

        [HttpGet("{gradeYearId}")]
        public async Task<ActionResult<List<StudentDto>>> GetStudentsByGradeYear(string gradeYearId)
        {
            var students = await _teacherService.GetStudentsByGradeYearIdAsync(gradeYearId);
            return Ok(students);
        }

        [HttpGet("grades/subject/{subjectId}")]
        public async Task<ActionResult<List<GradeDto>>> GetGradesBySubjectId(int subjectId)
        {
            var grades = await _teacherService.GetGradesBySubjectIdAsync(subjectId);
            return Ok(grades);
        }

        [HttpPost("opinions/add")]
        public async Task<ActionResult> AddOpinionToStudent(AddOpinionDto dto)
        {
            await _teacherService.AddOpinionToStudentAsync(dto);
            return Ok();
        }

    }
}
