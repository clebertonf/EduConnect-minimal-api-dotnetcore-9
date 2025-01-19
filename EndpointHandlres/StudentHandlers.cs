using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public static class StudentHandlers
{
    public static async Task<Ok<IEnumerable<StudentDto>>> GetStudentsAsync(ApplicationDbContext context, IMapper mapper)
    {
        var students = await context.Students.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<StudentDto>>(students));
    }
}