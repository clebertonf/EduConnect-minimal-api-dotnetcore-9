using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using EduConnect.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public static class CourseHandlers
{
    public static async Task<Ok<IEnumerable<CourseDto>>> GetCoursesAsync(ApplicationDbContext context, IMapper mapper)
    {
        var courses = await context.Courses.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<CourseDto>>(courses));
    }
}