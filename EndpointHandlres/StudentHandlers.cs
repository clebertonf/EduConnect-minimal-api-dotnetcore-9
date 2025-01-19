using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using EduConnect.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public static class StudentHandlers
{
    public static async Task<Ok<IEnumerable<StudentDto>>> GetStudentsAsync(ApplicationDbContext context, IMapper mapper)
    {
        var students = await context.Students.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<StudentDto>>(students));
    }
    
    public static async Task<Results<Ok<StudentDto>, NotFound>> GetStudentIdAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var student = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (student is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(mapper.Map<StudentDto>(student));
    }

    public static async Task<Results<Ok<Student>, NotFound>> GetStudentWithAddressAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var studentWithAddress = await context.Students
            .Include(s => s.Address)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        if(studentWithAddress is null)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(mapper.Map<Student>(studentWithAddress));
    }

    public static async Task<Results<Ok<Student>, NotFound>> GetStudentsWithEnrollmentsAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var studentWithEnrollments = await context.Students
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        if(studentWithEnrollments is null)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(mapper.Map<Student>(studentWithEnrollments));
    }

    public static async Task<Results<Ok<Student>, NotFound>> GetStudentWithCoursesAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var studentWithCourses = await context.Students
            .Include(s => s.Enrollments)!
            .ThenInclude(s => s.Course)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        
        if(studentWithCourses is null)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(mapper.Map<Student>(studentWithCourses));
    }
    
    public static async Task<CreatedAtRoute<StudentDto>> CreateStudentAsync(ApplicationDbContext context, IMapper mapper, [FromBody] StudentCreateDto studentDto)
    {
        var studentEntity = mapper.Map<Student>(studentDto);
        await context.Students.AddAsync(studentEntity);
        await context.SaveChangesAsync();
        var student = mapper.Map<StudentDto>(studentEntity);
        
        return TypedResults.CreatedAtRoute(student, "GetStudentById", new { id = studentEntity.Id});
    }

    public static async Task<Results<NoContent, BadRequest, NotFound>> UpdateStudentAsync(ApplicationDbContext context, IMapper mapper, [FromBody] StudentDto studentDto, int id)
    {
        if(studentDto.Id != id)
            return TypedResults.BadRequest();
        
        var studentEntity = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
        if(studentEntity is null)
            return TypedResults.NotFound();
        
        mapper.Map(studentDto, studentEntity);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    public static async Task<Results<NotFound, NoContent>> DeleteStudentAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var studentEntity = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (studentEntity is null)
            return TypedResults.NotFound();
        
        context.Students.Remove(studentEntity);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }
}