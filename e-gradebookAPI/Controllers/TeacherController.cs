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

        [HttpPost]
        public async Task<ActionResult> AddGrade([FromBody] AddGradeDto dto)
        {
            await _teacherService.AddGradeAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveGrade([FromBody]int id)
        {
            await _teacherService.RemoveGradeByIdAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> ReplaceGrade([FromBody] ReplaceGradeDto dto)
        {
            await _teacherService.ReplaceGradeAsync(dto);
            return Ok();
        }
    }
}
