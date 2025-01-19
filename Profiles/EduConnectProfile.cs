using AutoMapper;
using EduConnect.API.DTOS;
using EduConnect.API.Models;

namespace EduConnect.API.Profiles;

public class EduConnectProfile : Profile
{
    public EduConnectProfile()
    {
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<Student, StudentCreateDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
        CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
    }
}