using e_gradebookAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI
{
    public class AppSeeder
    {
        private readonly AppDbContext _context;

        public AppSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if(await _context.Database.CanConnectAsync())
            {
                if (!_context.Teachers.Any())
                {
                    var teachers = GetTeachers();
                    await _context.Teachers.AddRangeAsync(teachers);
                    await _context.SaveChangesAsync();
                }
                if (!_context.Subjects.Any())
                {
                    var subjects = GetSubjects();
                    await _context.Subjects.AddRangeAsync(subjects);
                    await _context.SaveChangesAsync();
                }
                if (!_context.Students.Any())
                {
                    var students = GetStudents();
                    await _context.Students.AddRangeAsync(students);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private static List<Subject> GetSubjects()
        {
            var subjects = new List<Subject>()
            {
                new Subject()
                {
                    Name = "Mathematics",
                    TeacherId=1
                },
                new Subject()
                {
                    Name = "Biology",
                    TeacherId=2
                },
                new Subject()
                {
                    Name = "Chemistry",
                    TeacherId=3
                },
                new Subject()
                {
                    Name = "History",
                    TeacherId=4
                },
                new Subject()
                {
                    Name = "Art",
                    TeacherId=5
                },
                new Subject()
                {
                    Name = "English",
                    TeacherId=6
                },
                new Subject()
                {
                    Name = "Science",
                    TeacherId=7
                }

            };
            return subjects;
        }
        private static List<Teacher> GetTeachers()
        {
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    FirstName = "Harry",
                    LastName = "Elliott",
                    DateOfBirth = new DateTime(1960,08,10)
                },
                new Teacher()
                {
                    FirstName = "Bryant",
                    LastName = "Twitty",
                    DateOfBirth = new DateTime(1990,08,10)
                },
                new Teacher()
                {
                    FirstName = "Moira",
                    LastName = "Sutton",
                    DateOfBirth = new DateTime(1988,01,12)
                },
                new Teacher()
                {
                    FirstName = "Tristram",
                    LastName = "Clarke",
                    DateOfBirth = new DateTime(1997,04,09)
                },
                new Teacher()
                {
                    FirstName = "Haley",
                    LastName = "Garrett",
                    DateOfBirth = new DateTime(1988,08,10)
                },
                new Teacher()
                {
                    FirstName = "Violet",
                    LastName = "Hart",
                    DateOfBirth = new DateTime(1977,04,12)
                },
                new Teacher()
                {
                    FirstName = "Ruby",
                    LastName = "Caldwell",
                    DateOfBirth = new DateTime(1980,10,19)
                },
            };

            return teachers;
        }
        private static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    FirstName = "Mark",
                    LastName = "Green",
                    DateOfBirth = new DateTime(2000,04,12)
                },
                new Student()
                {
                    FirstName = "Sophie",
                    LastName = "Waller",
                    DateOfBirth = new DateTime(2001,11,01)
                },
            };
            return students;
        }
        

    }
}
