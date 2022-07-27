using e_gradebookAPI.Dtos;
using e_gradebookAPI.Services.AccountService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AdminController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("account/registerstudent")]
        public async Task<ActionResult> RegisterNewStudent([FromBody]RegisterStudentDto dto)
        {
            await _accountService.RegisterNewStudent(dto);
            return Ok();

        }
    }
}
