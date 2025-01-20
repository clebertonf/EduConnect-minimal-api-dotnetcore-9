using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using EduConnect.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public static class CourseHandlers
{
    public static async Task<Ok<IEnumerable<CourseDto>>> GetCoursesAsync(ApplicationDbContext context, IMapper mapper)
    {
        var courses = await context.Courses.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<CourseDto>>(courses));
    }

    public static async Task<Results<Ok<CourseDto>, NotFound>> GetCourseByIdAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var course = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if (course is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(mapper.Map<CourseDto>(course));
    }

    public static async Task<CreatedAtRoute<CourseDto>> CreateCourseAsync(ApplicationDbContext context, IMapper mapper, [FromBody] CourseCreateDto course)
    {
        var courseEntity = mapper.Map<Course>(course);
        await context.Courses.AddAsync(courseEntity);
        await context.SaveChangesAsync();
        var courseDto = mapper.Map<CourseDto>(courseEntity);
        
        return TypedResults.CreatedAtRoute(courseDto, "GetCourseById", new { id = courseEntity.Id });
    }

    public static async Task<Results<BadRequest, NotFound, NoContent>> UpdateCourseAsync(ApplicationDbContext context, IMapper mapper, [FromBody] CourseDto course, int id)
    {
        if(course. Id != id)
            return TypedResults.BadRequest();
        
        var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if(courseEntity is null)
            return TypedResults.NotFound();
        
        mapper.Map(course, courseEntity);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    public static async Task<Results<NotFound, NoContent>> DeleteCourseAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var course = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if(course is null)
            return TypedResults.NotFound();
        
        context.Courses.Remove(course);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }
}