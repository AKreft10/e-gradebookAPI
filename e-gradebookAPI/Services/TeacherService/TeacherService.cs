using AutoMapper;
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
        private readonly IMapper _mapper;

        public TeacherService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<List<StudentDto>> GetStudentsByGradeYearIdAsync(string gradeYearId)
        {
            var students = await _context
                .Students
                .Where(z => z.GradeYear == gradeYearId)
                .ToListAsync();

            if (students is null)
                throw new NotFoundException("Students not found");

            var result = _mapper.Map<List<StudentDto>>(students);

            return result;
        }

        public async Task<List<StudentDto>> GetStudentsListAsync()
        {
            var students = await _context
                .Students
                .ToListAsync();

            if (students is null)
                throw new NotFoundException("Students not found");

            var result = _mapper.Map<List<StudentDto>>(students);

            return result;
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

        public async Task<List<GradeDto>> GetGradesBySubjectIdAsync(int subjectId)
        {
            var result = await _context
                .Grades
                .Include(z => z.Student)
                .Include(z => z.Subject)
                .Where(z => z.SubjectId == subjectId)
                .ToListAsync();

            if (result is null || result.Count == 0)
                throw new NotFoundException("Grades not found.");

            var grades = _mapper.Map<List<GradeDto>>(result);


            return grades;
        }

        public async Task AddOpinionToStudentAsync(AddOpinionDto dto)
        {
            //Just for test purposes, teacher will be recieved from claims

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(z => z.Id == 1);

            if (teacher is null)
                throw new Exception("teacher not found###Temporary exception###");

            var opinion = new Opinion
            {
                Content = dto.Content,
                CreationDate = DateTime.Now,
                CreatedBy = teacher,
                StudentId = dto.StudentId
            };

            await _context.AddAsync(opinion);
            await _context.SaveChangesAsync();
        }
    }
}