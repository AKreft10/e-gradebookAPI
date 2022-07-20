using AutoMapper;
using e_gradebookAPI.Data;
using e_gradebookAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Grade, GradeDto>();
            CreateMap<Grade, GradesByStudentDto>()
                .ForMember(d => d.SubjectName, o => o.MapFrom(x => x.Subject.Name));
        }
    }
}
