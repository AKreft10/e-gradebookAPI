using AutoMapper;
using e_gradebookAPI.Data;
using e_gradebookAPI.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GradesByStudentDto>> GetGradesByStudentIdAsync(int studentId)
        {
            var result = await _context
                .Grades
                .Include(z => z.Subject)
                .Where(z => z.StudentId == studentId)
                .ToListAsync();

            var grades = _mapper.Map<List<GradesByStudentDto>>(result);

            return grades;
        }

        public async Task<List<GradeDto>> GetGradesBySubjectIdAsync(int subjectId)
        {
            var result = await _context
                .Grades
                .Include(z => z.Student)
                .Include(z => z.Subject)
                .Where(z => z.SubjectId == subjectId)
                .ToListAsync();

            var grades = _mapper.Map<List<GradeDto>>(result);


            return grades;
        }
    }
}
