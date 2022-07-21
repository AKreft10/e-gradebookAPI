using e_gradebookAPI.Data;
using e_gradebookAPI.Dtos;
using e_gradebookAPI.Middleware.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _context;

        public TeacherService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddGradeAsync(AddGradeDto dto)
        {
            var grade = new Grade()
            {
                GradeValue = dto.GradeValue,
                GradeWeight = dto.GradeWeight,
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId
            };

            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveGradeByIdAsync(int id)
        {
            var gradeToRemove = await _context
                .Grades
                .FirstOrDefaultAsync(z => z.Id == id);

            if (gradeToRemove is null)
                throw new NotFoundException("Grade not found.");

            _context.Grades.Remove(gradeToRemove);
            await _context.SaveChangesAsync();
        }
        public async Task ReplaceGradeAsync(ReplaceGradeDto dto)
        {
            var grade = await _context
                .Grades
                .FirstOrDefaultAsync(z => z.Id == dto.Id);

            if (grade is null)
                throw new NotFoundException("Grade not found.");

            grade.GradeValue = dto.GradeValue;
            grade.GradeWeight = dto.GradeWeight;

            await _context.SaveChangesAsync();
        }
    }
}
